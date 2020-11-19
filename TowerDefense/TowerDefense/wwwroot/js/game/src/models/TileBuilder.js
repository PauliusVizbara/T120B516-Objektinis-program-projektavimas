class TileBuilder extends Builder {


    startNew(data) {
        this.data = data
    }

    build() {
        return new Tile(this.data)
    }

    addTileType(type) {
        this.data.type=type
    }

    addObstacle(sprite) {
        this.data.spriteData = sprite
    }

    addBuildReward(amount) {
        this.data.buildReward = amount
    }


}
