export function isValid(name)
{
    var regex = /^[A-Za-z\s]+$/
    if (regex.test(name))
    {
        return true
    }
    else
    {
        return false
    }
}