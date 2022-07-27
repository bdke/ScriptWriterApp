//window.getDimensions = function () {
//    return {
//        width: window.innerWidth,
//        height: window.innerHeight
//    };
//};

namespace Functions {
    class BrowserAction {
        public getWindowDimensions() {
            return {
                width: window.innerWidth,
                height: window.innerHeight
            }
        }
    }

    export function getBrowserAction(): BrowserAction {
        return new BrowserAction();
    }
}
