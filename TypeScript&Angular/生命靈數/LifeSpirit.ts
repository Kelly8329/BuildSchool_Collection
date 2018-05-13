interface INumerologyCalculator {
    getLifeNumerlogy(): number;
    getAstrologyConstellationName(): string;
}

class NumerologyCalculator implements INumerologyCalculator {

    private _birthYear: number;
    private _birthMonth: number;
    private _birthDay: number;

    constructor(year: number, month: number, day: number) {
        this._birthYear = year;
        this._birthMonth = month;
        this._birthDay = day;
    }

    getLifeNumerlogy(): number {
        let str = this._birthYear.toString() + this._birthMonth.toString() + this._birthDay.toString();
        return this.getLifeNumerologyInternal(str);
    }
    
    private getLifeNumerologyInternal(str: string): number {//計算生命靈數
        let result = 0;
        console.log(str);  

        for (var i = 0; i < str.length; i++) {
            result = result + parseInt(str[i]);
        }

        if (result > 9) {
            result = this.getLifeNumerologyInternal(result.toString())
        }
        return result;
    }

    getAstrologyConstellationName(): string {//判斷星座
        if (this._birthMonth == 1) {
            if (this._birthDay <= 20)
                return "capricorn";//摩羯座
            else
                return "aquarius";//水瓶座
        }
        else if (this._birthMonth == 2) {
            if (this._birthDay <= 19)
                return "aquarius";//水瓶座
            else
                return "pisces";//雙魚座
        }
        else if (this._birthMonth == 3) {
            if (this._birthDay <= 20)
                return "pisces";//雙魚座
            else
                return "aries";//牡羊座
        }
        else if (this._birthMonth == 4) {
            if (this._birthDay <= 19)
                return "aries";//牡羊座
            else
                return "taurus";//金牛座
        }
        else if (this._birthMonth == 5) {
            if (this._birthDay <= 20)
                return "taurus";//金牛座
            else
                return "gemini";//雙子座
        }
        else if (this._birthMonth == 6) {
            if (this._birthDay <= 21)
                return "gemini";//雙子座
            else
                return "cancer";//巨蠍座
        }
        else if (this._birthMonth == 7) {
            if (this._birthDay <= 22)
                return "cancer";//巨蠍座
            else
                return "leo";//獅子座
        }
        else if (this._birthMonth == 8) {
            if (this._birthDay <= 22)
                return "leo";//獅子座
            else
                return "virgo";//處女座
        }
        else if (this._birthMonth == 9) {
            if (this._birthDay <= 22)
                return "virgo";//處女座
            else
                return "libra";//天秤座
        }
        else if (this._birthMonth == 10) {
            if (this._birthDay <= 23)
                return "libra";//天秤座
            else
                return "scorpio";//天蠍座
        }
        else if (this._birthMonth == 11) {
            if (this._birthDay <= 21)
                return "scorpio";//天蠍座
            else
                return "sagittarius";//射手座
        }
        else if (this._birthMonth == 12) {
            if (this._birthDay <= 20)
                return "sagittarius";//射手座
            else
                return "capricorn";//摩羯座
        }
    }
}