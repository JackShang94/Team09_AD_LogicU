var win = new function () {
    // 确认框和提示框宽度
    this.width = 400;

    // 确认框和提示框高度
    this.height = 200;

    // 手动关闭窗体
    this.close = function () {
        $('.win iframe').remove();
        $('.win').remove();
    };

    // 打开窗体
    this.open = function (width, height, title, url, closed) {
        this._close = function () {
            this.close();
            if ($.isFunction(closed)) closed();
        };

        var html = '<div class="win"><div class="mask-layer"></div><div class="window-panel"><iframe class="title-panel" frameborder="0" marginheight="0" marginwidth="0" scrolling="no"></iframe><div class="title"><h3></h3></div><a href="javascript:void(0)" onclick="win._close();" class="close-btn" title="close">×</a><iframe class="body-panel" frameborder="0" marginheight="0" marginwidth="0" scrolling="auto" src=""></iframe></div></div>';
        var jq = $(html);
        jq.find(".window-panel").height(height).width(width).css("margin-left", -width / 2).css("margin-top", -height / 2);
        jq.find(".title").find(":header").html(title);
        jq.find(".body-panel").height(height - 36).attr("src", url);
        jq.appendTo('body').fadeIn();
        $(".win .window-panel").focus();
    };

    // 显示消息框
    function messageBox(html, title, message) {
        win.close();
        var jq = $(html);

        jq.find(".window-panel").height(win.height).width(win.width).css("margin-left", -win.width / 2).css("margin-top", -win.height / 2);
        jq.find(".title-panel").height(win.height);
        jq.find(".title").find(":header").html(title);win._close()
        jq.find(".body-panel").height(win.height - 100);
        jq.find(".content").html(message.replace('\r\n', '<br/>'));
        jq.appendTo('body').show();
        $(".win .w-btn:first").focus();
    }

   

    // 提示框
    this.alert = function (title, message, closed) {
        this._close = function () {
            this.close();
            if ($.isFunction(closed)) closed();
        };

        var html = '<div class="win"><div class="mask-layer "></div><div class="window-panel"><iframe class="title-panel" frameborder="0" marginheight="0" marginwidth="0" scrolling="no"></iframe><div class="title"><h3></h3></div><a href="javascript:void(0)" onclick="win._close();" class="close-btn" title="CLOSE">×</a><div class="body-panel"><div class="content"><div class=" sweet-alert show-sweet-alert icon success animate" style="display: block;"> <span class="line tip animate-success-tip"></span> <span class="line long animate-success-long"></span> <div class="placeholder"></div> <div class="fix"></div> </div></div><div class="btns"><button class="w-btn" tabindex="1" onclick="win._close();">OK</button></div></div></div></div>';
        messageBox(html, title, message);
    }

    // 提示框
    this.alertEx = function (message) {
        this.alert('Notic', message);
    }
};



