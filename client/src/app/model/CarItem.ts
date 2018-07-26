export class CarItem{
    private activePromotionName;

    constructor(public productID,
                public amount){}

    public setPromotion(promotion) {
        this.activePromotionName = promotion;
    }

    public getPromotion(){
        return this.activePromotionName;
    }
}