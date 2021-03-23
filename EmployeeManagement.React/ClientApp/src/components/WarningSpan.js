import React, { Component } from 'react'
import './style.css'

export class WarningSpan extends Component {
    constructor(props) {
        super(props);

        this.state = {
            message: props.message
        }
    }

    render() {
        return (
            <div class="warn-container">
                <p>{this.state.message}</p>
            </div>
        );
    }
}