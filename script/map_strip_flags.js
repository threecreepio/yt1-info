const INPUT = __dirname + '/gamedata/TOWN.DAT';
const OUTPUT = '/mnt/c/dev/dosbox/Yendor/TOWN.DAT';
const fs = require('fs');


const data = fs.readFileSync(INPUT);
for (var i=0; i < data.byteLength; i += 4) {
    var tile = i / 4;
    var tx = tile % 256;
    var ty = (tile / 256) | 0;

    let d = data.readInt32LE(i);

    // 0x
    // 0   - does stuff with doors and portals, at least
    // FFF - sprite
    // 0   - npc passability (at least)
    // 0   - unknown
    // 0   - player passability (at least)
    // F   - spritesheet
    // d = d & 0x0FFF000F;
    //d = d & 0xF0FF000F;

    // bits:
    // 00    : is portal (town exit)
    // 01    : is door (opens / pushes player through)
    // 03    : Unknown
    // 04    : Unknown
    // 05    : Enemy impassable
    // 06-16 : sprite index
    // 17    : Unknown
    // 18    : NPC passable 1
    // 19    : NPC passable 2
    // 20    : NPC passable 3
    // 21    : Unknown
    // 22    : Unknown
    // 23    : Unknown
    // 24    : Unknown
    // 25    : Player impassable 1
    // 26    : Player impassable 2
    // 27    : Unknown
    // 28    : Unknown
    // 29-32 : sprite sheet
    //d = d & 0b10010011111111110000000000001111;
    //d = d | 0b00001000000000000000000000000000;

    // d = d & 0b11111111111111111111111111111111;
    data.writeInt32LE(d, i);
}
fs.writeFileSync(OUTPUT, data);

