
var OfflineUtility = function (onlineCallback, offlineCallback, pollingUrl) {

  
    if (!pollingUrl)
    {
        pollingUrl = window.location.href;
    }

    var currentEventName = 'unkown',

        fireEvent = function (name, data) {
            var e = document.createEvent('Event');
            e.initEvent(name, true, true);
            e.data = data;
            window.dispatchEvent(e);
        },

        fireEventIfStatusChanges = function (eventName) {
            if (currentEventName != eventName) {
                currentEventName = eventName;
                fireEvent(eventName, {});
            }
        },

        getUrl = function () {
           
            return pollingUrl;
        },

        detectOnlineStatus = function (url) {
            $.get(url).done(function () {                
                fireEventIfStatusChanges('onlineCustom');
            }).fail(function () {
                fireEventIfStatusChanges('offlineCustom')
            });
        },

        autoReloadOnCacheUpdate = function () {
            window.applicationCache.swapCache();
            location.reload();
        };

    if (onlineCallback) {
        window.addEventListener("onlineCustom", onlineCallback);
    }
    if (onlineCallback) {
        window.addEventListener("offlineCustom", offlineCallback);
    }
    if (onlineCallback || offlineCallback) {
        detectOnlineStatus();
        setInterval(function () {
            var url = getUrl();
            detectOnlineStatus(url);

        }, 1000);
    }
    
};




$(function () {

    var btn = $('#submit')[0];
    var msg = $('#msg');
    
    msg.className = "alert alert-danger alert-dismissible";
    msg.hidden = true;
    var p = document.createElement("p");
    
    
    var doWhenOnline = function () {
        btn.disabled = false;
        msg.attr("hidden", true);
    },
    
    doWhenOffline = function () {
        btn.disabled = true;
        msg.attr("hidden", false);
        msg.append(document.createTextNode('You are now working offline'));        
    };

     var offlineUtility = new OfflineUtility(doWhenOnline, doWhenOffline);

}); 
