const fs = require('fs');
var itemList = require('./items.js').list;
listVendors();

function listVendors() {
    const PROG = './gamedata/PROG9.EXE';
    var data = fs.readFileSync(PROG);
    for (var i=0; i<data.length - 0x20; ++i) {
        var start = i;
        // search for BUY dialog option
        if ("BUY    " !== data.slice(start, start + 7).toString('utf8')) {
            continue;
        }
        
        console.log('\nNEW VENDOR:');
        while ("  " === data.slice(start + 17, start + 19).toString('utf8')) {
            // skip extra dialog options (BUY and PAY)
            start += 10;
        }

        var count = data.readUInt8(start + 20);
        var start = start + 21;
        for (var j=0; j<count; ++j) {
            var itemId = data.readUInt16LE(start + (j * 2));
            
            var itemInfo = itemList.find(x => x.id === itemId);
            console.log(itemId.toString(16).padStart(4, '0') + ': ' + (itemInfo ? itemInfo.name : '(unknown)'));
        }
    }
}
