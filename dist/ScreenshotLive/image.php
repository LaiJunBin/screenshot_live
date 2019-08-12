<?php

    header('content-type: image/png');
    $filename = 'screen.png';
    do {
        $image = @imagecreatefrompng($filename);
    } while($image == null);

    imagepng($image);
    imagedestroy($image);

    