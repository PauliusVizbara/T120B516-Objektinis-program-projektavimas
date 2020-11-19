class Entity {
    constructor(data) {
        const { tile, currentHealth, sprite, onClick } = data
        this.tile = tile
        this.info
        this.spriteData = sprite
        this.sprite = PIXI.Sprite.from(this.spriteData.spritePath)
        this.onClick = onClick
        if (currentHealth) this.maxHealth = currentHealth
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

        if (this.maxHealth) {
            const healthBar = new PIXI.Container();
            healthBar.position.set(-50, -10)

            let innerBar = new PIXI.Graphics();
            innerBar.beginFill(0x000000);
            innerBar.drawRect(0, 0, 100, 15);
            innerBar.endFill();
            healthBar.addChild(innerBar);

            let outerBar = new PIXI.Graphics();
            outerBar.beginFill(0xFF3300);
            outerBar.drawRect(0, 0, 100, 15);
            outerBar.endFill();
            healthBar.addChild(outerBar);

            healthBar.outer = outerBar;

            this.sprite.addChild(healthBar);
            this.healthBar = healthBar
        }
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
