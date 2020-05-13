

function createStuf() {
    const PARTY_INVSTART = 0xC8;
    const TOWN_PROG = './gamedata/PROG5.EXE';
    const TOWN_INVSTART = 0x56e6;

    const SRCPATH = './gamedata/SAVEGAME.A/_PARTY.DAT';
    const DESTPATH = './gamedata/SAVEGAME.A/PARTY.DAT';

    const fs = require('fs');
    var townData = fs.readFileSync(TOWN_PROG);
    var partyData = fs.readFileSync(SRCPATH);

    var items = [];


    for (var i=0; i<349; ++i) {
        var mem = (i * 2) + PARTY_INVSTART;
        var name_mem = (i * 35) + TOWN_INVSTART;
        //partyData.writeUInt16LE(i % 255, mem);
        var itemName = townData.slice(name_mem, name_mem + 20).toString('utf8');
        var itemData = Array.from(townData.slice(name_mem + 20, name_mem + 35))
            .map(v => Number(v).toString(16).padStart(2, '0'))
            .join(' ');

        items.push({
            id: (1+i),
            idStr: (1+i).toString(16).padStart(4, '0'),
            name: itemName,
            details: itemData
        });

        //console.log((1+i).toString(16).padStart(3, '0') + ' (' + mem.toString(16).padStart(3, '0') + ') ' + itemName + '    ' + itemData);
    }
    console.log(JSON.stringify(items, null, 4));
    //fs.writeFileSync(DESTPATH, partyData);
}
