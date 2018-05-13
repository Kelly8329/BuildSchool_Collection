var NumerologyCalculator = (function () {
    function NumerologyCalculator(year, month, day) {
        this._birthYear = year;
        this._birthMonth = month;
        this._birthDay = day;
    }
    NumerologyCalculator.prototype.getLifeNumerlogy = function () {
        var str = this._birthYear.toString() + this._birthMonth.toString() + this._birthDay.toString();
        return this.getLifeNumerologyInternal(str);
    };
    NumerologyCalculator.prototype.getLifeNumerologyInternal = function (str) {
        var result = 0;
        console.log(str);
        for (var i = 0; i < str.length; i++) {
            result = result + parseInt(str[i]);
        }
        if (result > 9) {
            result = this.getLifeNumerologyInternal(result.toString());
        }
        return result;
    };
    NumerologyCalculator.prototype.getAstrologyConstellationName = function () {
        if (this._birthMonth == 1) {
            if (this._birthDay <= 20)
                return "capricorn";
            else
                return "aquarius";
        }
        else if (this._birthMonth == 2) {
            if (this._birthDay <= 19)
                return "aquarius";
            else
                return "pisces";
        }
        else if (this._birthMonth == 3) {
            if (this._birthDay <= 20)
                return "pisces";
            else
                return "aries";
        }
        else if (this._birthMonth == 4) {
            if (this._birthDay <= 19)
                return "aries";
            else
                return "taurus";
        }
        else if (this._birthMonth == 5) {
            if (this._birthDay <= 20)
                return "taurus";
            else
                return "gemini";
        }
        else if (this._birthMonth == 6) {
            if (this._birthDay <= 21)
                return "gemini";
            else
                return "cancer";
        }
        else if (this._birthMonth == 7) {
            if (this._birthDay <= 22)
                return "cancer";
            else
                return "leo";
        }
        else if (this._birthMonth == 8) {
            if (this._birthDay <= 22)
                return "leo";
            else
                return "virgo";
        }
        else if (this._birthMonth == 9) {
            if (this._birthDay <= 22)
                return "virgo";
            else
                return "libra";
        }
        else if (this._birthMonth == 10) {
            if (this._birthDay <= 23)
                return "libra";
            else
                return "scorpio";
        }
        else if (this._birthMonth == 11) {
            if (this._birthDay <= 21)
                return "scorpio";
            else
                return "sagittarius";
        }
        else if (this._birthMonth == 12) {
            if (this._birthDay <= 20)
                return "sagittarius";
            else
                return "capricorn";
        }
    };
    return NumerologyCalculator;
}());
//# sourceMappingURL=LifeSpirit.js.map