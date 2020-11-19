class Tile {

    colors = {
        ground: [0x59CD90, 0x37AB70, 0x257750],
        path: [0xb27826, 0x966520, 0x5e3f14],
        water: [0x0bbebe, 0x0bbebe, 0x0bbebe]
    }
    constructor(data) {
        const { stage, x, y, tileRenderPoint, entityRenderPoint, type, spriteData } = data
        this.x = x
        this.y = y
        this.tileRenderPoint = tileRenderPoint
        this.entityRenderPoint = { x: this.tileRenderPoint.x + cellSize * 0.85, y: this.tileRenderPoint.y + cellSize * 0.7 }
        this.stage = stage
        this.type = type
        this.spriteData = spriteData
        if (spriteData) this.sprite = PIXI.Sprite.from(spriteData.spritePath)
        this.color = this.colors[type] || this.colors.ground
        this.onClick = () => {
            uiManager.showTowerBuildingMenu({ x: this.x, y: this.y })
        }
        this.onMouseUpOutside = () => {
            uiManager.hideMenus()
            console.log('mouse up oustide')
        }
    }

    render() {
        renderIsometricTile(this.onClick, this.onMouseUpOutside, this.tileRenderPoint.x, this.tileRenderPoint.y, cellSize, cellHeight, this.color[0], this.color[1], this.color[2])
        console.log(this.sprite,this.spriteData)
        if (this.spriteData) {
            this.sprite.position.x = this.entityRenderPoint.x
            this.sprite.position.y = this.entityRenderPoint.y
            this.sprite.anchor.x = this.spriteData.pivot ? this.spriteData.pivot[0] : 0.5
            this.sprite.anchor.y = this.spriteData.pivot ? this.spriteData.pivot[1] : 1
            this.sprite.scale.set(this.spriteData.scale[0], this.spriteData.scale[1])     
            viewport.addChild(this.sprite)
        }
    }
}
