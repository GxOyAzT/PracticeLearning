import React, { Component } from 'react'
import './style.css'
import { WarningSpan } from './WarningSpan';
import { ValidationMoney } from '../validation/ValidateMoneyTextForm'
import * as ValidateFullName from '../validation/ValidateFullName'
import { DeleteEmployee, UpdateEmployee } from '../fetchData/EmployeeBaseData'

export class EmployeeModel extends Component
{
    constructor(props) {
        super(props);

        this.state = {
            employee: props.employee,
            salary: props.salary,
            warning: false,
            warningMessage: null
        }

        this.deleteEmployee = this.deleteEmployee.bind(this)
        this.updateEmployee = this.updateEmployee.bind(this)
    }

    changeFullName = (e) => {
        this.removeWarningContainer()
        if (!ValidateFullName.isValid(e.target.value)) {
            this.setState({
                warning: true,
                warningMessage: 'Incorrect full name format. Full name can contains only letters and spaces.'
            })
            return
        }

        var employee = this.state.employee
        employee.fullName = e.target.value
        this.setState({
            employee: employee
        })
    }

    changeGender = (e) => {
        this.removeWarningContainer()
        var employee = this.state.employee
        employee.gender = e.target.value
        this.setState({
            employee: employee
        })
    }

    changeSalary = (e) => {
        this.removeWarningContainer()
        var employee = this.state.employee
        employee.salary = e.target.value
        this.setState({
            employee: employee
        })
    }

    removeWarningContainer = () => {
        this.setState({
            warning: false,
            warningMessage: null
        })
    }

    changeDob = (e) => {
        this.removeWarningContainer()
        var employee = this.state.employee
        employee.dateOfBirth = e.target.value
        this.setState({
            employee: employee
        })
    }

    deleteEmployee() {
        DeleteEmployee(this.state.employee.id)
    }

    updateEmployee() {
        UpdateEmployee(this.state.employee)
    }

    render() {
        return (
            <div className="employee-model-container">
                <div className="inline-block">
                    <label>Full Name:</label>
                    <br/>
                    <input value={this.state.employee.fullName} onChange={this.changeFullName}></input>
                </div>
                <div className="inline-block">
                    <label>Salary:</label>
                    <br />
                    <input value={this.state.employee.salary} onChange={this.changeSalary}></input>
                </div>
                <div className="inline-block">
                    <label>Gender:</label>
                    <br />
                    <select value={this.state.employee.gender} onChange={this.changeGender}>
                        <option value="0">Male</option>
                        <option value="1">Female</option>
                        <option value="2">Other</option>
                    </select>
                </div>
                <div className="inline-block">
                    <label>Dob:</label>
                    <br />
                    <input type="date" value={this.state.employee.dateOfBirth.toString().split('T')[0]} onChange={this.changeDob}></input>
                </div>
                <div className="inline-block">
                    <button onClick={this.deleteEmployee}>DELETE</button>
                    <button onClick={this.updateEmployee}>UPDATE</button>
                </div>

                { this.state.warning == true ? <WarningSpan message={this.state.warningMessage}/> : ''}
            </div>
            );
    }
}