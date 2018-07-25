/*
Copyright (c) 2003-2009, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';

    //toolbar
    config.toolbar = 'MXICToolbar';
    config.toolbar_MXICToolbar =
    [
    ['FontSize'],
	['Bold', 'Italic', 'Underline', 'Strike', '-', 'TextColor', 'BGColor', '-',
	 'Link', 'Unlink', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock',
	 '-', 'Outdent', 'Indent', '-', 'PasteText'],
    ];
    //Whether to remove links when emptying the link URL field in the Image dialog window.
    config.image_removeLinkByEmptyURL = false;
    //bold italic
    config.coreStyles_bold = { element: 'b', overrides: 'strong' };
    config.coreStyles_italic = { element: 'i', overrides: 'em' };
    //disable resize
    config.resize_enabled = false;
    //Enter <br>
    config.enterMode = CKEDITOR.ENTER_BR;
    //remove bottom,x scroll bar
    config.removePlugins = 'magicline,autogrow,elementspath';
    // Simplify the dialog windows.
    config.removeDialogTabs = 'image:advanced;link:advanced;link:target;';
    // This is actually the default value for it.
    config.fontSize_style =
    {
        element: 'font',
        styles: { 'font-size': '#(size)' },
        overrides: [{ element: 'font', attributes: { 'size': null}}]
    };
    config.colorButton_backStyle =
    {
        element: 'font',
        styles: { 'background-color': '#(color)' }
    };
    config.colorButton_foreStyle =
    {
        element: 'font',
        styles: { 'color': '#(color)' }
    };
};