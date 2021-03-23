import React, { Component } from 'react'
import { EmployeeModel } from './EmployeeModel'
import * as EmployeeBaseData from '../fetchData/EmployeeBaseData.js'

export class EmployeeList extends Component {
    static displayName = EmployeeList.name;

    constructor(props) {
        super(props);

        this.state = {
            employees: null
        }
    }

    async componentDidMount() {
        this.setState({
            employees: (await EmployeeBaseData.GetAllEmployee()).data
        }, () => console.log(this.state.employees))
        
    }

    render() {
        var employeeList = null
        if (this.state.employees != null)
            employeeList = this.state.employees.map(employee => <EmployeeModel key={employee.id} employee={employee}/>)

        return (
            <div>
                <h1>Employee List</h1>
                <div>{this.state.employees == null ? <p>Loading...</p> : employeeList}</div>
            </div>
        );
    }
}