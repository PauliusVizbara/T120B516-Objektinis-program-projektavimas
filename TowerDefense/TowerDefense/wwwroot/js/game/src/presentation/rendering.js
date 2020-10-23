
function renderIsometricTile(onClick, onMouseUpOutside, x, y, size, height, topColor, leftColor, rightColor) {
    var topSide = new PIXI.Graphics();
    topSide.beginFill(topColor);
    topSide.drawRect(0, 0, size, size);
    topSide.endFill();
    topSide.setTransform(x, y + size * 0.5, 1, 1, 0, 1.1, -0.5, 0, 0);
    topSide.interactive = true
    topSide.on('mousedown', onClick)
    topSide.on('mouseupoutside', onMouseUpOutside)

    var leftSide = new PIXI.Graphics();

    leftSide.beginFill(leftColor);
    leftSide.drawRect(0, 0, height, size);
    leftSide.endFill();
    leftSide.setTransform(x, y + size * 0.5, 1, 1, 0, 1.1, 1.57, 0, 0);

    var rightSide = new PIXI.Graphics();

    rightSide.beginFill(rightColor);
    rightSide.drawRect(0, 0, size, height);
    rightSide.endFill();
    rightSide.setTransform(x, y + size * 0.5, 1, 1, 0, -0.0, -0.5, -(size + (size * 0.015)), -(size - (size * 0.06)));

    viewport.addChild(topSide);
    viewport.addChild(leftSide);
    viewport.addChild(rightSide);

    return topSide
    // var centerPoint = new PIXI.Graphics();
    // centerPoint.beginFill(0xFF0000);
    // centerPoint.drawRect(x + size * 0.85, y + size * 0.65, 2, 2);
    // centerPoint.endFill();
    // centerPoint.setTransform(x, y + size * 0.5, 1, 1, 0, 1.1, -0.5, 0, 0);
    // viewport.addChild(centerPoint)

    // let sprite = PIXI.Sprite.from('/CTD/assets/monsterTile1.png')
    // sprite.position.x = x + size * 0.85
    // sprite.position.y = y + size * 0.65
    // sprite.anchor.x = 0.5
    // sprite.anchor.y = 1
    // sprite.scale.set(0.3,0.3)
    // viewport.addChild(sprite)
}
