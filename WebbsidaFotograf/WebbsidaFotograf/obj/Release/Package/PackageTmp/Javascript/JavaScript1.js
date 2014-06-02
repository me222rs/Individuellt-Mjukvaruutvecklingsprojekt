(function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/sv_SE/all.js#xfbml=1";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

(function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/sv_SE/all.js#xfbml=1";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));


!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');


function SelectText() {
    var textValue = document.selection.createRange().text;
    document.form1.TextBox1.value = textValue;
}

// Function to add <tag>To Selected text</tag> in textarea with id of idelm
// Receives the tag name, and the id of textarea.
// Points the cursor at the end of selected text in textarea
// Returns the selected text, with tag
//function addTagSel(tag, idelm) {
//    // http://CoursesWeb.net/javascript/
//    var tag_type = new Array('<', '>');        // for BBCode tag, replace with:  new Array('[', ']');
//    var txta = document.getElementById(idelm);
//    var start = tag_type[0] + tag + tag_type[1];
//    var end = tag_type[0] + '/' + tag + tag_type[1];
//    var IE = /*@cc_on!@*/false;    // this variable is false in all browsers, except IE

//    if (IE) {
//        var r = document.selection.createRange();
//        var tr = txta.createTextRange();
//        var tr2 = tr.duplicate();
//        tr2.moveToBookmark(r.getBookmark());
//        tr.setEndPoint('EndToStart', tr2);
//        var tag_seltxt = start + r.text + end;
//        var the_start = txta.value.replace(/[\r\n]/g, '.').indexOf(r.text.replace(/[\r\n]/g, '.'), tr.text.length);
//        txta.value = txta.value.substring(0, the_start) + tag_seltxt + txta.value.substring(the_start + tag_seltxt.length, txta.value.length);

//        var pos = txta.value.length - end.length;    // Sets location for cursor position
//        tr.collapse(true);
//        tr.moveEnd('character', pos);        // start position
//        tr.moveStart('character', pos);        // end position
//        tr.select();                 // selects the zone
//    }
//    else if (txta.selectionStart || txta.selectionStart == '0') {
//        var startPos = txta.selectionStart;
//        var endPos = txta.selectionEnd;
//        var tag_seltxt = start + txta.value.substring(startPos, endPos) + end;
//        txta.value = txta.value.substring(0, startPos) + tag_seltxt + txta.value.substring(endPos, txta.value.length);

//        // Place the cursor between formats in #txta
//        txta.setSelectionRange((endPos + start.length), (endPos + start.length));
//        txta.focus();
//    }
//    return tag_seltxt;
//}