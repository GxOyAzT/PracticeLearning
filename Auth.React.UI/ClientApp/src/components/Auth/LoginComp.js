import React, { Component } from 'react';
import { loginUser } from '../../fetch-data/Auth/AccountFetch'
import { createCookie } from '../../cookies-manage/CreateCookie'


export class LoginComp extends Component {
    constructor(props) {
        super(props);

        this.state = {
            username: '',
            password: '',
            isUserLoggedIn: props.isUserLoggedIn
        }

        this.handleLoginChange = props.handleLoginChange.bind(this)
        this.onClickSubmit = this.onClickSubmit.bind(this)
    }

    onChangeUsername = (e) => {
        this.setState({
            username: e.target.value
        })
    }

    onChangePassword = (e) => {
        this.setState({
            password: e.target.value
        })
    }

    async onClickSubmit() {
        var result = await loginUser(this.state.username, this.state.password)

        this.props.handleLoginChange(true)

        createCookie('BearerToken', result.token)
    }

    render() {
        return (
            <div>
                <h1>Login</h1>
                <input type="text" placeholder="username" value={this.state.username} onChange={this.onChangeUsername}></input>
                <input type="password" placeholder="password" value={this.state.password} onChange={this.onChangePassword}></input>
                <button onClick={this.onClickSubmit}>Submit</button>
            </div>
        );
    }
}
