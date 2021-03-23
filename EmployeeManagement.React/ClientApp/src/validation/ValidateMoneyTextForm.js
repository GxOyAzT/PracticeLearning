export function isValid(money) {
    var regex = /^[1-9][0-9]{3,4}[,][0-9]{2}$/

    if (regex.exec(money)) {
        return true
    }
    else {
        return false
    }
}