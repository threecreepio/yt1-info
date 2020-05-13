const fs = require('fs');
const _ = require('lodash')
var tileset = require('./tileset.js');
const Canvas = require('canvas')
const chests = require('./chests.js');


const MAP = 'TOWN';

const MAPINDEX = ['WORLD', 'TOWN', 'MINE'].indexOf(MAP);
let W = 0xFF;
let H = 0xFF;
let data = fs.readFileSync('./gamedata/' + MAP + '.DAT');
// let data = fs.readFileSync('./gamedata/TOWN.DAT');
// let data = fs.readFileSync('./gamedata/MINE.DAT');
let drawWorldChests = true;

const canvas = new Canvas(32 * W, 32 * H)
const ctx = canvas.getContext('2d');

for (var y=0; y<H; ++y) {
    console.log('drawing line ', y);
    for (var x=0; x<W; ++x) {
        var mem = ((y * (W + 1)) + x) * 4;
        var tile = data.readUInt32LE(mem);
        tileset.drawTile(tile, ctx, x * 32, y * 32);
        const chest = chests[MAPINDEX + '_' + x + '_' + y];
        if (chest) {
            tileset.drawTile(0x01CF0002, ctx, x * 32, y * 32);
            var txt = '#' + chest.idx;
            ctx.fillStyle = 'rgba(255, 255, 255, 0.5)';
            //ctx.textBaseline = 'top';
            var width = ctx.measureText(txt).width;
            ctx.fillRect(x * 32, y * 32, 32, 32);
            ctx.fillStyle = '#000';
            ctx.fillText(txt, (x * 32) + 16 - (width / 2), (y * 32) + 16);
        }
    }
}

var out = fs.createWriteStream('./out.' + MAP + '.png');
var stream = canvas.pngStream();
stream.pipe(out);
