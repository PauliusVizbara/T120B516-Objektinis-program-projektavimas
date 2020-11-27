class Entity {
    constructor(data) {
        const { tile, currentHealth, sprite, onClick, renderBuilder } = data
        this.tile = tile
        this.info
        this.spriteData = sprite
        this.sprite = PIXI.Sprite.from(this.spriteData.spritePath)
        this.onClick = onClick
        this.renderBuilder = new renderBuilder(data)
        if (currentHealth) this.maxHealth = currentHealth
    }

    render() {
        this.renderBuilder.renderEntity(this)
    }

    setHealth(health) {
        this.healthBar.outer.width = health
    }

    remove() {
        console.log(this.sprite, viewport.removeChild)
        viewport.removeChild(this.sprite)
    }

    move(tile) {
        this.tile = tile
        this.sprite.position.x = this.tile.entityRenderPoint.x
        this.sprite.position.y = this.tile.entityRenderPoint.y
    }
}
