import React, { Component } from 'react'
import { Route } from 'react-router'
import { Layout } from './components/Layout'
import { Home } from './components/Home'
import { FetchData } from './components/FetchData'
import { Counter } from './components/Counter'
import { LoginComp } from './components/Auth/LoginComp'
import { isLoggedIn } from './fetch-data/Auth/AccountFetch'

import './custom.css'

export default class App extends Component {
  static displayName = App.name

    constructor() {
        super()

        this.state = {
            isUserLoggedIn: false
        }

        this.handleLoginChange = this.handleLoginChange.bind(this)
    }

    handleLoginChange(actualState) {
        this.setState({
            isUserLoggedIn: actualState
        })
    }

    async componentDidMount() {
        this.setState({
            isUserLoggedIn: await isLoggedIn()
        })
    }

  render () {
      return (
          this.state.isUserLoggedIn == false ?
              <LoginComp isUserLoggedIn={this.state.isUserLoggedIn} handleLoginChange={this.handleLoginChange} /> :
              <p>Logged in.</p>
          //<Layout>
      //  <Route exact path='/' component={Home} />
      //  <Route path='/counter' component={Counter} />
      //  <Route path='/fetch-data' component={FetchData} />
      //</Layout>
    );
  }
}
