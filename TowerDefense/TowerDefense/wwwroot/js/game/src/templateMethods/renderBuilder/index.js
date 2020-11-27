class AbstractRenderBuilder {
    constructor(data) {
        if (new.target === AbstractRenderBuilder) {
            throw new TypeError("Cannot construct AbstractRenderBuilder instances directly");
        }
        this.data = data
    }

    renderEntity(ref) {
        this.addSprite(ref)
        if (this.data.currentHealth) this.addHealthBar(ref)
        if (this.data.onClick) this.addOnClick(ref)
    }

    addSprite(ref) {
        ref.sprite.position.x = ref.tile.entityRenderPoint.x
        ref.sprite.position.y = ref.tile.entityRenderPoint.y
        ref.sprite.anchor.x = ref.spriteData.pivot ? ref.spriteData.pivot[0] : 0.5
        ref.sprite.anchor.y = ref.spriteData.pivot ? ref.spriteData.pivot[1] : 1
        ref.sprite.scale.set(ref.spriteData.scale[0], ref.spriteData.scale[1])
        viewport.addChild(ref.sprite)
    }

    addOnClick(ref) { }

    addHealthBar(ref) {}


}

class TowerRenderBuilder  extends AbstractRenderBuilder {
    constructor(data) {
        super(data)
    }
   
    addOnClick(ref) {
        console.log(ref.onClick)
        ref.sprite.interactive = true
        ref.sprite.on('mousedown', ref.onClick)
    }
}

class MonsterRenderBuilder extends AbstractRenderBuilder {
    constructor(data) {
        super(data)
    }

    addHealthBar(ref) {
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

        ref.sprite.addChild(healthBar);
        ref.healthBar = healthBar
        
    }
}