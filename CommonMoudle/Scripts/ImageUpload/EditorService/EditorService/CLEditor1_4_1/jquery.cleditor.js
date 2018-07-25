﻿/*!
CLEditor WYSIWYG HTML Editor v1.4.1
http://premiumsoftware.net/CLEditor
requires jQuery v1.4.2 or later
Copyright 2010, Chris Landowski, Premium Software, LLC
Dual licensed under the MIT or GPL Version 2 licenses.
*/
(function (n) {
    function ci(t) { var i = this, v = t.target, w = n.data(v, a), b = o[w], k = b.popupName, nt = f[k], p, d; if (!i.disabled && n(v).attr(r) != r) { if (p = { editor: i, button: v, buttonName: w, popup: nt, popupName: k, command: b.command, useCSS: i.options.useCSS }, b.buttonClick && b.buttonClick(t, p) === !1) return !1; if (w == "source") l(i) ? (delete i.range, i.$area.hide(), i.$frame.show(), v.title = b.title) : (i.$frame.hide(), i.$area.show(), v.title = "Show Rich Text"), setTimeout(function () { c(i) }, 100); else if (!l(i)) { if (k) { if (d = n(nt), k == "url") { if (w == "link" && ni(i) === "") return g(i, "請選擇欲插入連結的文字", v), !1; d.children(":button").unbind(u).bind(u, function () { var t = d.find(":text"), r = n.trim(t.val()); r !== "" && s(i, p.command, r, null, p.button), t.val("http://"), e(), h(i) }) } else k == "pastetext" && d.children(":button").unbind(u).bind(u, function () { test(i); var n = d.find("textarea"), t = n.val().replace(/\n/g, "<br />"); t !== "" && s(i, p.command, t, null, p.button), n.val(""), e(), h(i) }); return v !== n.data(nt, y) ? (ti(i, nt, v), !1) : void 0 } if (w == "print") i.$frame[0].contentWindow.print(); else if (!s(i, p.command, p.value, p.useCSS, v)) return !1 } h(i) } } function pt(t) { var i = n(t.target).closest("div"); i.css(tt, i.data(a) ? "#FFF" : "#FFC") } function wt(t) { n(t.target).closest("div").css(tt, "transparent") } function li(i) { var v = this, p = i.data.popup, r = i.target, l; if (p !== f.msg && !n(p).hasClass(w)) { var k = n.data(p, y), u = n.data(k, a), b = o[u], d = b.command, c, g = v.options.useCSS; if (u == "font" ? c = r.style.fontFamily.replace(/"/g, "") : u == "size" ? (r.tagName == "DIV" && (r = r.children[0]), c = r.innerHTML) : u == "style" ? c = "<" + r.tagName + ">" : u == "color" ? c = dt(r.style.backgroundColor) : u == "highlight" && (c = dt(r.style.backgroundColor), t ? d = "backcolor" : g = !0), l = { editor: v, button: k, buttonName: u, popup: p, popupName: b.popupName, command: d, value: c, useCSS: g }, !b.popupClick || b.popupClick(i, l) !== !1) { if (l.command && !s(v, l.command, l.value, l.useCSS, k)) return !1; e(), h(v) } } } function k(n) { for (var t = 1, r = 0, i = 0; i < n.length; ++i) t = (t + n.charCodeAt(i)) % 65521, r = (r + t) % 65521; return r << 16 | t } function ai(n) { n.$area.val(""), nt(n) } function bt(r, u, e, o, s) { var h, c; return f[r] ? f[r] : (h = n(i).hide().addClass(fi).appendTo("body"), o ? h.html(o) : r == "color" ? (c = u.colors.split(" "), c.length < 10 && h.width("auto"), n.each(c, function (t, r) { n(i).appendTo(h).css(tt, "#" + r) }), e = ei) : r == "font" ? n.each(u.fonts.split(","), function (t, r) { n(i).appendTo(h).css("fontFamily", r).html(r) }) : r == "size" ? n.each(u.sizes.split(","), function (t, r) { n(i).appendTo(h).html("<span style='font-size:" + r + ";'>" + r + "<\/span>") }) : r == "style" ? n.each(u.styles, function (t, r) { n(i).appendTo(h).html(r[1] + r[0] + r[1].replace("<", "<\/")) }) : r == "url" ? (h.html('輸入URL<br><input type=text value="http://" size=35><br><input type=button value="確認">'), e = w) : r == "pastetext" && (h.html("請貼上複製文字<br /><textarea cols=40 rows=3><\/textarea><br /><input type=button value=確認>"), e = w), e || o || (e = at), h.addClass(e), t && h.attr(it, "on").find("div,font,p,h1,h2,h3,h4,h5,h6").attr(it, "on"), (h.hasClass(at) || s === !0) && h.children().hover(pt, wt), f[r] = h[0], h[0]) } function kt(n, i) { i ? (n.$area.attr(r, r), n.disabled = !0) : (n.$area.removeAttr(r), delete n.disabled); try { t ? n.doc.body.contentEditable = !i : n.doc.designMode = i ? "off" : "on" } catch (u) { } c(n) } function s(n, i, r, u, f) {
        d(n), t || ((u === undefined || u === null) && (u = n.options.useCSS), n.doc.execCommand("styleWithCSS", 0, u.toString())); var e = !0, o;

        //for emylife event
        var ss = n.$frame.contents().find('body').text();
        if (ss.indexOf('點擊以編輯') != -1 || ss.indexOf('請輸入活動') != -1 || ss.indexOf('選單項目') != -1 || ss.indexOf('點擊這裡編輯') != -1 || ss.indexOf('按此編輯youtube') != -1 || ss.indexOf('點這裡編輯') != -1 || ss.indexOf('點這裡開始編輯') != -1 || ss.indexOf('點這裡輸入') != -1) {
            n.$frame.contents().find('body').text('');
        }

        if (t && i.toLowerCase() == "inserthtml") {
            try {
                v(n).pasteHTML(r);
            }
            catch (e) {
                // An empty document needs selection beforehand
                if (/^\s*$/.test(n.doc.body.innerText)) {
                    n.doc.execCommand('selectAll', false, null);
                }

                // execCommand is the standard method for contentEditable elements
                n.doc.execCommand("Paste", 0, r || null);
            }
        }
        else {
            try {
                if (i == "fontsize") {
                    switch (r) {
                        case "8pt":
                            r = "1";
                            break;
                        case "10pt":
                            r = "2";
                            break;
                        case "12pt":
                            r = "3";
                            break;
                        case "14pt":
                            r = "4";
                            break;
                        case "18pt":
                            r = "5";
                            break;
                        case "24pt":
                            r = "6";
                            break;
                        case "36pt":
                            r = "7";
                            break;
                    }
                }

                e = n.doc.execCommand(i, 0, r || null);
                if (i == "fontsize") {
                    var fontElements = n.doc.getElementsByTagName("font");
                    for (var i = 0, len = fontElements.length; i < len; ++i) {
                        switch (fontElements[i].size) {
                            case "1":
                                fontElements[i].removeAttribute("size");
                                fontElements[i].style.fontSize = "8pt";
                                break;
                            case "2":
                                fontElements[i].removeAttribute("size");
                                fontElements[i].style.fontSize = "10pt";
                                break;
                            case "3":
                                fontElements[i].removeAttribute("size");
                                fontElements[i].style.fontSize = "12pt";
                                break;
                            case "4":
                                fontElements[i].removeAttribute("size");
                                fontElements[i].style.fontSize = "14pt";
                                break;
                            case "5":
                                fontElements[i].removeAttribute("size");
                                fontElements[i].style.fontSize = "18pt";
                                break;
                            case "6":
                                fontElements[i].removeAttribute("size");
                                fontElements[i].style.fontSize = "24pt";
                                break;
                            case "7":
                                fontElements[i].removeAttribute("size");
                                fontElements[i].style.fontSize = "36pt";
                                break;
                        }
                    }
                }
            }
            catch (s) { o = s.message, e = !1 }

            e || ("cutcopypaste".indexOf(i) > -1 ? g(n, "For security reasons, your browser does not support the " + i + " command. Try using the keyboard shortcut or context menu instead.", f) : g(n, o ? o : "Error executing the " + i + " command.", f))
        }


        return c(n), ot(n, !0), e
    } function h(n) {

        setTimeout(function () { l(n) ? n.$area.focus() : n.$frame[0].contentWindow.focus(), c(n) }, 0)
    } function v(n) { return t ? ft(n).createRange() : ft(n).getRangeAt(0) } function ft(n) { return t ? n.doc.selection : n.$frame[0].contentWindow.getSelection() } function dt(n) { var i = /rgba?\((\d+), (\d+), (\d+)/.exec(n), t; if (i) { for (n = (i[1] << 16 | i[2] << 8 | i[3]).toString(16); n.length < 6; ) n = "0" + n; return "#" + n } return (t = n.split(""), n.length == 4) ? "#" + t[1] + t[1] + t[2] + t[2] + t[3] + t[3] : n } function e() { n.each(f, function (t, i) { n(i).hide().unbind(u).removeData(y) }) } function gt() { var t = "jquery.cleditor.css", i = n("link[href$='" + t + "']").attr("href"); return i.substr(0, i.length - t.length) + "images/" } function vi(n) { return "url(" + gt() + n + ")" } function et(i) { var o = i.$main, r = i.options; i.$frame && i.$frame.remove(); var u = i.$frame = n('<iframe frameborder="0" src="javascript:true;">').hide().appendTo(o), l = u[0].contentWindow, f = i.doc = l.document, s = n(f); f.open(), f.write(r.docType + "<html>" + (r.docCSSFile === "" ? "" : '<head><link rel="stylesheet" type="text/css" href="' + r.docCSSFile + '" /><\/head>') + '<body style="' + r.bodyStyle + '"><\/body><\/html>'), f.close(), t && s.click(function () { h(i) }), nt(i), t && (s.bind("beforedeactivate beforeactivate selectionchange keypress", function (n) { if (n.type == "beforedeactivate") i.inactive = !0; else if (n.type == "beforeactivate") !i.inactive && i.range && i.range.length > 1 && i.range.shift(), delete i.inactive; else if (!i.inactive) for (i.range || (i.range = []), i.range.unshift(v(i)); i.range.length > 2; ) i.range.pop() }), u.focus(function () { d(i) })), s.click(e).bind("keyup mouseup", function () { c(i), ot(i, !0) }), rt ? i.$area.show() : u.show(), n(function () { var t = i.$toolbar, f = t.children("div:last"), e = o.width(), n = f.offset().top + f.outerHeight() - t.offset().top + 1; t.height(n), n = (/%/.test("" + r.height) ? o.height() : parseInt(r.height)) - n, u.width(e).height(n), i.$area.width(e).height(si ? n - 2 : n), kt(i, i.disabled), c(i) }) } function c(i) { var u, e; rt || !hi || i.focused || (i.$frame[0].contentWindow.focus(), window.focus(), i.focused = !0), u = i.doc, t && (u = v(i)), e = l(i), n.each(i.$toolbar.find("." + ct), function (o, s) { var v = n(s), h = n.cleditor.buttons[n.data(s, a)], c = h.command, l = !0, y; if (i.disabled) l = !1; else if (h.getEnabled) y = { editor: i, button: s, buttonName: h.name, popup: f[h.popupName], popupName: h.popupName, command: h.command, useCSS: i.options.useCSS }, l = h.getEnabled(y), l === undefined && (l = !0); else if ((e || rt) && h.name != "source" || t && (c == "undo" || c == "redo")) l = !1; else if (c && c != "print" && (t && c == "hilitecolor" && (c = "backcolor"), !t || c != "inserthtml")) try { l = u.queryCommandEnabled(c) } catch (p) { l = !1 } l ? (v.removeClass(lt), v.removeAttr(r)) : (v.addClass(lt), v.attr(r, r)) }) } function d(n) { t && n.range && n.range[0].select() } function yi(n) { setTimeout(function () { l(n) ? n.$area.select() : s(n, "selectall") }, 0) } function pi(i) { var u, r, f; return (d(i), u = v(i), t) ? u.htmlText : (r = n("<layer>")[0], r.appendChild(u.cloneContents()), f = r.innerHTML, r = null, f) } function ni(n) { return (d(n), t) ? v(n).text : ft(n).toString() } function g(n, t, i) { var r = bt("msg", n.options, oi); r.innerHTML = t, ti(n, r, i) } function ti(t, i, r) { var f, h, c, o = n(i), l, s; r ? (l = n(r), f = l.offset(), h = --f.left, c = f.top + l.height()) : (s = t.$toolbar, f = s.offset(), h = Math.floor((s.width() - o.width()) / 2) + f.left, c = f.top + s.height() - 2), e(), o.css({ left: h, top: c }).show(), r && (n.data(i, y, r), o.bind(u, { popup: i }, n.proxy(li, t))), setTimeout(function () { o.find(":text,textarea").eq(0).focus().select() }, 100) } function l(n) { return n.$area.is(":visible") } function nt(t, i) { var u = t.$area.val(), o = t.options, f = o.updateFrame, s = n(t.doc.body), e, r; if (f) { if (e = k(u), i && t.areaChecksum == e) return; t.areaChecksum = e } r = f ? f(u) : u, r = r.replace(/<(?=\/?script)/ig, "&lt;"), o.updateTextArea && (t.frameChecksum = k(r)), r != s.html() && (s.html(r), n(t).triggerHandler(p)) } function ot(t, i) { var u = n(t.doc.body).html(), o = t.options, f = o.updateTextArea, s = t.$area, e, r; if (f) { if (e = k(u), i && t.frameChecksum == e) return; t.frameChecksum = e } r = f ? f(u) : u, o.updateFrame && (t.areaChecksum = k(r)), r != s.val() && (s.val(r), n(t).triggerHandler(p)) } var ut, yt; n.cleditor = { defaultOptions: { width: "auto", height: 250, controls: "bold italic underline strikethrough subscript superscript | font size style | color highlight removeformat | bullets numbering | outdent indent | alignleft center alignright justify | undo redo | rule image link unlink | cut copy paste pastetext | print source", colors: "FFF FCC FC9 FF9 FFC 9F9 9FF CFF CCF FCF CCC F66 F96 FF6 FF3 6F9 3FF 6FF 99F F9F BBB F00 F90 FC6 FF0 3F3 6CC 3CF 66C C6C 999 C00 F60 FC3 FC0 3C0 0CC 36F 63F C3C 666 900 C60 C93 990 090 399 33F 60C 939 333 600 930 963 660 060 366 009 339 636 000 300 630 633 330 030 033 006 309 303", fonts: "Arial,Arial Black,Comic Sans MS,Courier New,Narrow,Garamond,Georgia,Impact,Sans Serif,Serif,Tahoma,Trebuchet MS,Verdana", sizes: "1,2,3,4,5,6,7", styles: [["Paragraph", "<p>"], ["Header 1", "<h1>"], ["Header 2", "<h2>"], ["Header 3", "<h3>"], ["Header 4", "<h4>"], ["Header 5", "<h5>"], ["Header 6", "<h6>"]], useCSS: !0, docType: '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">', docCSSFile: "", bodyStyle: "margin:4px; font:10pt Arial,Verdana; cursor:text" }, buttons: { init: "bold,粗體,|italic,斜體,|underline,底線,|strikethrough,刪除線,|subscript,,|superscript,,|font,字型,fontname,|size,字型大小,fontsize,|style,,formatblock,|color,字體顏色,forecolor,|highlight,文字提示顏色,hilitecolor,color|removeformat,Remove Formatting,|bullets,項目符號,insertunorderedlist|numbering,編號,insertorderedlist|outdent,消失縮排,|indent,增加縮排,|alignleft,靠左對齊,justifyleft|center,置中,justifycenter|alignright,靠右對齊,justifyright|justify,左右對齊,justifyfull|undo,,|redo,,|rule,Insert Horizontal Rule,inserthorizontalrule|image,Insert Image,insertimage,url|link,請選擇欲插入連結的文字,createlink,url|unlink,取消超連結,|cut,,|copy,,|paste,,|pastetext,請貼上複製文字,inserthtml,|print,,|source,Show Source" }, imagesPath: function () { return gt() } }, n.fn.cleditor = function (t) { var i = n([]); return this.each(function (r, u) { if (u.tagName == "TEXTAREA") { var f = n.data(u, st); f || (f = new cleditor(u, t)), i = i.add(f) } }), i }; var tt = "backgroundColor", y = "button", a = "buttonName", p = "change", st = "cleditor", u = "click", r = "disabled", i = "<div>", it = "unselectable", ii = "cleditorMain", ri = "cleditorToolbar", ht = "cleditorGroup", ct = "cleditorButton", lt = "cleditorDisabled", ui = "cleditorDivider", fi = "cleditorPopup", at = "cleditorList", ei = "cleditorColor", w = "cleditorPrompt", oi = "cleditorMsg", b = navigator.userAgent.toLowerCase(), t = /msie/.test(b), si = /msie\s6/.test(b), hi = /webkit/.test(b), rt = /iphone|ipad|ipod/i.test(b), f = {}, vt, o = n.cleditor.buttons; n.each(o.init.split("|"), function (n, t) { var i = t.split(","), r = i[0]; o[r] = { stripIndex: n, name: r, title: i[1] === "" ? r.charAt(0).toUpperCase() + r.substr(1) : i[1], command: i[2] === "" ? r : i[2], popupName: i[3] === "" ? r : i[3]} }), delete o.init, cleditor = function (r, f) { var s = this; s.options = f = n.extend({}, n.cleditor.defaultOptions, f); var l = s.$area = n(r).hide().data(st, s).blur(function () { nt(s, !0) }), v = s.$main = n(i).addClass(ii).width(f.width).height(f.height), y = s.$toolbar = n(i).addClass(ri).appendTo(v), h = n(i).addClass(ht).appendTo(y), c = 0; n.each(f.controls.split(" "), function (r, e) { var w, l, p, v; if (e === "") return !0; e == "|" ? (w = n(i).addClass(ui).appendTo(h), h.width(c + 1), c = 0, h = n(i).addClass(ht).appendTo(y)) : (l = o[e], p = n(i).data(a, l.name).addClass(ct).attr("title", l.title).bind(u, n.proxy(ci, s)).appendTo(h).hover(pt, wt), c += 24, h.width(c + 1), v = {}, l.css ? v = l.css : l.image && (v.backgroundImage = vi(l.image)), l.stripIndex && (v.backgroundPosition = l.stripIndex * -24), p.css(v), t && p.attr(it, "on"), l.popupName && bt(l.popupName, f, l.popupClass, l.popupContent, l.popupHover)) }), v.insertBefore(l).append(l), vt || (n(document).click(function (t) { var i = n(t.target); i.add(i.parents()).is("." + w) || e() }), vt = !0), /auto|%/.test("" + f.width + f.height) && n(window).bind("resize.cleditor", function () { et(s) }), et(s) }, ut = cleditor.prototype, yt = [["clear", ai], ["disable", kt], ["execCommand", s], ["focus", h], ["hidePopups", e], ["sourceMode", l, !0], ["refresh", et], ["select", yi], ["selectedHTML", pi, !0], ["selectedText", ni, !0], ["showMessage", g], ["updateFrame", nt], ["updateTextArea", ot]], n.each(yt, function (n, t) { ut[t[0]] = function () { for (var i = this, r = [i], u, n = 0; n < arguments.length; n++) r.push(arguments[n]); return (u = t[1].apply(i, r), t[2]) ? u : i } }), ut.change = function (t) { var i = n(this); return t ? i.bind(p, t) : i.trigger(p) }
})(jQuery);

function test(i) {
    if (i.$frame.contents().find("body").text().replace(/^\s+|\s+$/g, "") === "") {
        i.$frame.contents().find("body").html("");
    }
};

(function ($) {

    // Define the hello button
    $.cleditor.buttons.popup = {
        name: "popup",
        image: "popup.png",
        title: "Insert Popup",
        command: "inserthtml",
        popupName: "popup",
        popupClass: "cleditorPrompt",
        popupContent: "Enter popup title:<br><input style='width:300px;'><br>Enter popup content:<br><textarea style='width:300px; height:200px;'></textarea><br><input type=button value=Submit>",
        buttonClick: popupClick
    };

    // Add the button to the default controls before the bold button
    $.cleditor.defaultOptions.controls = $.cleditor.defaultOptions.controls
    .replace("bold", "hello bold");

    // Handle the hello button click event
    function popupClick(e, data) {

        // Wire up the submit button click event
        $(data.popup).children(":button")
      .unbind("click")
      .bind("click", function (e) {

          // Get the editor
          var editor = data.editor;
          var clicktext = editor.selectedText();

          // Get the entered popup title
          var title = $(data.popup).find(":text").val();
          $(data.popup).find(":text").val("");

          // Get the entered popup content
          var content = $(data.popup).find("textarea").val();
          $(data.popup).find("textarea").val("");

          // Insert some html into the document
          var html = "[popup title=\"" + title + "\" content=\"" + content + "\" text=\"" + clicktext + "\"]";
          if (clicktext !== "") {
              editor.execCommand(data.command, html, null, data.button);
          }
          // Hide the popup and set focus back to the editor
          editor.hidePopups();
          editor.focus();

      });

    }

    $.cleditor.buttons.outerlink = {
        name: "outerlink",
        image: "outerlink.png",
        title: "請選擇欲插入連結的文字",
        command: "inserthtml",
        popupName: "outerlink",
        popupClass: "cleditorPrompt",
        popupContent: "請輸入連結網址：<br><input style='width:235px;' value='http://'><br><input type=button value=確認>",
        buttonClick: outerlinkClick
    };

    // Handle the hello button click event
    function outerlinkClick(e, data) {
        if (data.editor.selectedText() === "") {
            $(".cleditorMsg").show();
            return false;
        }
        else {
            // Wire up the submit button click event
            $(data.popup).children(":button")
      .unbind("click")
      .bind("click", function (e) {

          // Get the editor
          var editor = data.editor;
          var clicktext = editor.selectedText();

          // Get the entered outerlink
          var outerlink = $(data.popup).find(":text").val();
          $(data.popup).find(":text").val("");

          // Insert some html into the document
          var html = "<a href=\"" + outerlink + "\" target=\"_blank\" >" + clicktext + "</a>";

          editor.execCommand(data.command, html, null, data.button);

          // Hide the popup and set focus back to the editor
          editor.hidePopups();
          editor.focus();

      });
        }
    }


    //輪播專用
    $.cleditor.buttons.bannerOuterlink = {
        name: "bannerOuterlink",
        image: "outerlink.png",
        title: "超連結",
        command: "inserthtml",
        popupName: "bannerOuterlink",
        popupClass: "cleditorPrompt",
        popupContent: "<INPUT TYPE=CHECKBOX NAME='inline'>直接導頁<INPUT TYPE=CHECKBOX NAME='outopen'>新開頁面<BR><input style='width:235px;' value='http://'><br><input type=button value=確認>",
        buttonClick: bannerOuterlinkClick
    };

    
    function bannerOuterlinkClick(e, data) {
        // Get the editor
        var editor = data.editor;
        var editText = editor.$frame.contents().find('body').html();
        if(editText.indexOf('[OpenNewPage]') != -1)
        {
            $(data.popup).find('[type]')[1].checked = true;
            $(data.popup).find(":text").val(editText.substring(13));
        }
        else if (editText.indexOf('http://') != -1)
        {
            $(data.popup).find('[type]')[0].checked = true;
            $(data.popup).find(":text").val(editText);
        }



        // Wire up the submit button click event
        $(data.popup).children(":button").unbind("click").bind("click", function (e) {
          
          // Get the entered linkURL
          var linkURL = $(data.popup).find(":text").val();
          if($(data.popup).find('[type]')[0].checked == true && $(data.popup).find('[type]')[1].checked == true)
          {
                alert("只能選擇一項。");     
                $(data.popup).find('[type]')[0].checked =false;
                $(data.popup).find('[type]')[1].checked =false;
                return false;
          }
          else if($(data.popup).find('[type]')[0].checked == false && $(data.popup).find('[type]')[1].checked ==false)
          {
                alert("至少選擇一項。");     
                return false;
          }
          else if($(data.popup).find('[type]')[1].checked == true)
          {
                linkURL = "[OpenNewPage]" + linkURL;
          }
          
          editor.$frame.contents().find('body').html("");
          editor.execCommand(data.command, linkURL, null, data.button);
          
          //reset
          $(data.popup).find(":text").val('http://');
          $(data.popup).find('[type]')[0].checked =false;
          $(data.popup).find('[type]')[1].checked =false;
          // Hide the popup and set focus back to the editor
          editor.hidePopups();
          editor.focus();
         
      });
        $(".cleditorPrompt").css({ 'height': '10px' });
     }

})(jQuery);