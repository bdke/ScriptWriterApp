//window.getDimensions = function () {
//    return {
//        width: window.innerWidth,
//        height: window.innerHeight
//    };
//};
var Functions;
(function (Functions) {
    var BrowserAction = /** @class */ (function () {
        function BrowserAction() {
        }
        BrowserAction.prototype.getWindowDimensions = function () {
            return {
                width: window.innerWidth,
                height: window.innerHeight
            };
        };
        return BrowserAction;
    }());
    function getBrowserAction() {
        return new BrowserAction();
    }
    Functions.getBrowserAction = getBrowserAction;
})(Functions || (Functions = {}));
//# sourceMappingURL=Functions.js.map