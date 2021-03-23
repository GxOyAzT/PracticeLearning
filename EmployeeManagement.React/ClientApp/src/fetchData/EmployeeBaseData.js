import * as  Api from './ApiDomain.js'

export async function GetAllEmployee() {
    var response = await fetch(`${Api.GetApiDomain()}/api1.1/employee`)
    var objects = await response.json()
    var output = {
        statusCode: response.status,
        data: objects
    }
    return output
}

export async function DeleteEmployee(empId) {
    const options = {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
    }
    var response = await fetch(`${Api.GetApiDomain()}/api1.1/Employee/${empId}`, options)
    var output = {
        statusCode: response.status,
    }
    console.log(output.statusCode)
    return output
}

export async function UpdateEmployee(emp) {
    const options = {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(emp)
    }
    var response = await fetch(`${Api.GetApiDomain()}/api1.1/Employee`, options).catch((error) => { console.log(error) })
    var output = {
        statusCode: response.status,
    }
    console.log(output.statusCode)
    return output
}