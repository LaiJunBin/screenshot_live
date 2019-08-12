const screenMain = document.getElementById('screen-main');
const screenCanvas = document.getElementById('screen-canvas');
const screenContext = screenCanvas.getContext('2d');
const snapshotCanvas = document.getElementById('snapshot-canvas');
const snapshotContext = snapshotCanvas.getContext('2d');

const openFullScreenBtn = document.getElementById('open-full-screen-btn');

const screenIndexRange = document.getElementById('screen-index-range');
var screenIndexRangeFocus = false;

var screenImages = [];

screenIndexRange.addEventListener('mousedown', function (e) {
    snapshotCanvas.style.display = 'unset';
    screenIndexRangeFocus = true;
});

screenIndexRange.addEventListener('mousemove', function (e) {
    let mouseX = e.clientX;
    snapshotCanvas.style.left = Math.min(mouseX, document.body.clientWidth - snapshotCanvas.width) +
        'px';
    snapshotCanvas.style.top = (e.target.offsetTop - snapshotCanvas.height) + 'px';
    let index = screenIndexRange.value;
    let image = screenImages[index];
    snapshotContext.drawImage(image, 0, 0, image.width, image.height, 0, 0, snapshotCanvas.width,
        snapshotCanvas.height);
});


screenIndexRange.addEventListener('mouseup', function (e) {
    snapshotCanvas.style.display = 'none';
    screenIndexRangeFocus = false;
})

function getScreenImage() {
    return new Promise((resolve, reject) => {
        let image = new Image();
        image.src = './image.php?n=' + Math.random();
        image.onload = function () {
            if (screenCanvas.width != this.width) {
                screenCanvas.width = screenCanvas.width || this.width;
                screenCanvas.height = screenCanvas.height || this.height;
                snapshotCanvas.width = this.width / 5;
                snapshotCanvas.height = this.height / 5;
            }
            screenImages.push(image);
            let screenImageIndex = parseInt(screenIndexRange.value) + 1;
            resolve(Math.min(screenImageIndex, screenImages.length - 1));
        }
    });
}

function renderScreenImage() {
    getScreenImage().then(index => {
        let image;
        if (!screenIndexRangeFocus) {
            image = screenImages[index];
            screenIndexRange.max = screenImages.length;
            screenIndexRange.value = index;
        } else {
            image = screenImages[screenIndexRange.value];
        }
        screenContext.drawImage(image, 0, 0, image.width, image.height, 0, 0, screenCanvas.width,
            screenCanvas.height);
    });
}

setInterval(() => {
    renderScreenImage();
}, 75);

function openFullscreen() {
    if (screenMain.requestFullscreen) {
        screenMain.requestFullscreen();
    } else if (screenMain.mozRequestFullScreen) {
        /* Firefox */
        screenMain.mozRequestFullScreen();
    } else if (screenMain.webkitRequestFullscreen) {
        /* Chrome, Safari and Opera */
        screenMain.webkitRequestFullscreen();
    } else if (screenMain.msRequestFullscreen) {
        /* IE/Edge */
        screenMain.msRequestFullscreen();
    }
}

openFullScreenBtn.addEventListener('click', openFullscreen);