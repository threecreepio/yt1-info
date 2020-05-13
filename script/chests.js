
const INPUT = __dirname + '/gamedata/PROG4.EXE';
const OUTPUT = '/mnt/c/dev/dosbox/Yendor/PROG4.EXE';
const fs = require('fs');
var data = fs.readFileSync(INPUT);
var base = 0x15813;
var itemList = require('./items.js').list;

const WORLD = '1 2 3 4 9 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29'.split(/\s/).map(v => parseInt(v, 10));
const MINE = '5 6 7 8 10 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 58 59 60 61 62 63 64 65 66 67 68 69 70 71 72 73 74 75 76 77 78 79 80 81 82 83 84 85 86 87 88 89 90 91 92 93 94 95'.split(/\s/).map(v => parseInt(v, 10));
const TOWN = [0];
const MAPS = [WORLD, TOWN, MINE];

const chests = {};
const chestList = [];
for (var i=0; i<0x60; ++i) {
    var start = base + (i * 0x19);
    var f1 = data.readUInt8(start + 0x0);
    var x = data.readUInt8(start + 0x1);
    var y = data.readUInt8(start + 0x2);
    var f2 = data.readUInt8(start + 0x3);
    var f3 = data.readUInt8(start + 0x18);
    var gold = data.readInt16LE(start + 0x4);

    const chest = {};
    chest.flags = [f1, f2, f3];
    chest.idx = i;
    chest.x = x;
    chest.y = y;
    chest.map = MAPS.findIndex(m => m.indexOf(i) > -1);
    chest.gold = gold;
    chest.items = [];

    data.writeUInt8(10 + i, start + 0x1);
    data.writeUInt8(10, start + 0x2);

    for (var j=0; j<6; ++j) {
        var jstart = start + 0x6 + (j * 0x3);
        var count = data.readUInt8(jstart + 0x0);
        var itemId = data.readInt16LE(jstart + 0x1);
        var itemInfo = itemList.find(x => x.id === itemId);
        const itemIdHex = itemId.toString(16).padStart(3, '0');
        chest.items.push({
            item: itemInfo ? '(' + itemIdHex + ') ' + itemInfo.name : '(' + itemIdHex + ') ???',
            count: count
        });
    }
    chests[chest.map + '_' + x + '_' + y] = chest;
    chestList.push(chest);
}

// fs.writeFileSync(OUTPUT, data);
module.exports = chests;

function createDataFile() {
    for (var i=0; i < chestList.length; ++i) {
        console.log('');
        var chest = chestList[i];

        // tile coords
        var coordsXY = 'C(' + chest.x.toString(16).padStart(2, '0') + ',' + chest.y.toString(16).padStart(2, '0') + ')';
    
        // pixel coords
        var coordsPX = 'PX(' + String(chest.x * 32).padStart(2, '0') + ',' + String(chest.y * 32).padStart(2, '0') + ')';

        const mapName = ['WORLD', 'TOWN', 'MINE'][chest.map];
    
        console.log('chest ' + i + ' in ' + mapName + ' ' + coordsXY + ' ' + coordsPX);
        console.log('flags'.padEnd(30) + ': ' + JSON.stringify(chest.flags.map(x => x .toString(16))));
        if (chest.gold) console.log('Gold'.padEnd(30) + ': ' + chest.gold);

        for (var j=0; j<chest.items.length; ++j) {
            var it = chest.items[j];
            if (!it.count) continue;
            console.log(it.item.padEnd(30) + ': ' + it.count);
        }
    }
}
createDataFile();
