class Tile {

    colors = {
        ground: [0x59CD90, 0x37AB70, 0x257750],
        path: [0xb27826, 0x966520, 0x5e3f14],
    }
    constructor(data) {
        const { stage, x, y, tileRenderPoint, entityRenderPoint, type } = data
        this.x = x
        this.y = y
        this.tileRenderPoint = tileRenderPoint
        this.entityRenderPoint = { x: this.tileRenderPoint.x + cellSize * 0.85, y: this.tileRenderPoint.y + cellSize * 0.7 }
        this.stage = stage
        this.type = type
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
    }
}
