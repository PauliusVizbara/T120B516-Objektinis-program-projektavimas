class Entity {
    constructor(data) {
        const { tile, sprite, onClick } = data
        this.tile = tile
        this.info
        this.spriteData = sprite
        this.sprite = PIXI.Sprite.from(this.spriteData.spritePath)
        this.onClick = onClick
    }

    render() {
        this.sprite.position.x = this.tile.entityRenderPoint.x
        this.sprite.position.y = this.tile.entityRenderPoint.y
        this.sprite.anchor.x = this.spriteData.pivot ? this.spriteData.pivot[0] : 0.5
        this.sprite.anchor.y = this.spriteData.pivot ? this.spriteData.pivot[1] : 1
        this.sprite.scale.set(this.spriteData.scale[0], this.spriteData.scale[1])
        if (this.onClick) {
            this.sprite.interactive = true
            this.sprite.on('mousedown', this.onClick)
        }
        viewport.addChild(this.sprite)
    }

    move(tile) {
        this.tile = tile
        this.sprite.position.x = this.tile.entityRenderPoint.x
        this.sprite.position.y = this.tile.entityRenderPoint.y
    }
}
