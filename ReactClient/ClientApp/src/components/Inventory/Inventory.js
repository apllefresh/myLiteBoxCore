import React, { Component } from 'react';
import Dropdown from 'react-dropdown'
import 'react-dropdown/style.css'

export class Inventory extends Component {
    displayName = Inventory.name

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };

        fetch('api/inventory/')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });
    }

    static renderForecastsTable(forecasts) {
        var options = [];
        
        for (var i = 0; i < forecasts.length; i++) {
            if (forecasts[i].Header !== "id") {
                var transformed = {
                    label: forecasts[i].date,
                    value: forecasts[i].id
                };
                options.push(transformed);
            }
        }
       
        return (
            <Dropdown options={options}  placeholder="Select an option" />
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Inventory.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1>Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}