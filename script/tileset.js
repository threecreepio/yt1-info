const fs = require('fs');

const spritesheets = [];
function getSpritesheet(i) {
    if (!spritesheets[i]) {
        spritesheets[i] = fs.readFileSync('./gamedata/FILE0' + Number(i) + '.16');
    }
    return spritesheets[i];
}

function exportSpritesheet(sheetidx) {
    var PER_ROW = 0xA; // 14;
    const Canvas = require('canvas')
    var sheetSize = (getSpritesheet(sheetidx).byteLength) / 512;
    const canvas = new Canvas(32 * PER_ROW, 32 * Math.ceil(sheetSize / PER_ROW));
    const ctx = canvas.getContext('2d')


    for (var i=0; i<sheetSize; ++i) {
        var x = (i % PER_ROW) * 32;
        var y = ((i / PER_ROW) | 0) * 32;
        if (!drawSheetSprite(sheetidx, i, ctx, x, y)) {
            console.log('failed to draw sprite ' + i.toString(16));
        }
    }

    var out = fs.createWriteStream('./spritesheets/' + sheetidx + '.png');
    var stream = canvas.pngStream();
    stream.pipe(out);
}
/*
exportSpritesheet(0);
exportSpritesheet(1);
exportSpritesheet(2);
exportSpritesheet(3);
exportSpritesheet(4);
exportSpritesheet(5);
exportSpritesheet(6);
*/

exports.drawTile = drawTile;

function drawTile(tile, canvas, cvsx, cvsy) {
    // FLAG4
    // SPR3
    // SPR2
    // SPR1
    // FLAG3
    // FLAG2
    // FLAG1
    // SPRITESHEET

    var sheetidx = tile & 0x0000000F;
    var tileidx = (tile & 0x07FF0000) >> 16;
    return drawSheetSprite(sheetidx, tileidx, canvas, cvsx, cvsy);
}

function drawSheetSprite(sheetidx, num, canvas, cvsx, cvsy) {
    var spritesheet = getSpritesheet(sheetidx);
    var colors = [];
    for (var i=0; i<(64*64); ++i) colors.push(0);
    for (var clr=0; clr<4; ++clr) {
        for (var py=0; py<32; ++py) {
            var mem = (((clr * 32) + py) * 4) + (num * 512);
            var value = mem > (spritesheet.length - 4) ? 0 : spritesheet.readUInt32BE(mem);
            for (var px=0; px<32; ++px) {
                if (value >> px & 1) {
                    colors[(py * 32) + (31 - px)] |= (1 << clr);
                }
            }
        }
    }

    var failed = false;
    for (var py=0; py<32; ++py) {
        //var line = '';
        for (var px=0; px<32; ++px) {
            var color = colors[(py * 32) + px];
            switch (color) {
                case 0:
                    canvas.fillStyle = "#000000";
                    break;
                case 1:
                    canvas.fillStyle = '#1b5503';
                    break;
                case 2:
                    canvas.fillStyle = "#560c0b";
                    break;
                case 3:
                    canvas.fillStyle = "#f66161";
                    break;
                case 4:
                    canvas.fillStyle = "#9f9f9f";
                    break;
                case 5:
                    canvas.fillStyle = '#84c60c';
                    break;
                case 6:
                    canvas.fillStyle = '#3ba1d8'; // alternates between 3ba1d8 and 0055a9
                    break;
                case 7:
                    canvas.fillStyle = '#0056aa';
                    break;
                case 8:
                    canvas.fillStyle = "#606060";
                    break;
                case 9:
                    canvas.fillStyle = '#3e9929';
                    break;
                case 10:
                    canvas.fillStyle = "#aa5606";
                    break;
                case 11:
                    canvas.fillStyle = '#3ba1d8'; // blinks between 3ba1d8 (1 frame) and 0055a9 (more frames)
                    break;
                case 12:
                    canvas.fillStyle = '#b4b46b';
                    break;
                case 13:
                    canvas.fillStyle = "#aa0000";
                    break;
                case 14:
                    canvas.fillStyle = '#f6a14d';
                    break;
                case 15:
                    canvas.fillStyle = "#ffffff";
                    break;
                default:
                    failed = true;
                    console.warn('unhandled color ' + color);
                    canvas.fillStyle = 'magenta';
                    break;
            }
            //line += color.toString(16) + ' ';
            canvas.fillRect( cvsx+px, cvsy+py, 1, 1 );
        }
        //console.log(line);
    }

    return !failed;
}
