import { getApiDomain } from '../ApiDomain'
import { findCookie } from '../../cookies-manage/FindCookie'

export async function loginUser(username, password) {
    return await fetch(`${getApiDomain()}/api/user/login`,
    {
        body: JSON.stringify({
            username: username,
            password: password
        }),
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
    })
    .then(response => {
        //if (!(response.status === 200)) {
        //    return { result: 'FAILURE', token: null }
        //}
        //return { result: 'OK', token: response.json() }
        return response.json()
    }).then(data => {
        //if (!(data. === 200)) {
        //    return data
        //}
        return { result: 'OK', token: data.token }
    })
}

export async function isLoggedIn() {
    var bearerToken = findCookie('BearerToken')
    if (bearerToken == null) {
        return false
    }

    return await fetch(`${getApiDomain()}/api/user/connectionclose`,
        {
            headers: {
                Authorization: `Bearer ${bearerToken}`
            }
        }).then(response =>
        {
            if (response.status === 200) {
                return true
            }
            else return false
        }).then(x => x)
}