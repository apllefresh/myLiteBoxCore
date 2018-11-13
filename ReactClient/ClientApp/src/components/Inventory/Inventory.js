import React, { Component,  Button, ModalHeader } from 'react';
import Dropdown from 'react-dropdown'
import 'react-dropdown/style.css'
import DatePicker from 'react-date-picker';
import InventoryDateAdd  from './InventoryDateAdd';


export class Inventory extends Component {
    displayName = Inventory.name

    constructor(props) {
        super(props);
        this.state = { dateOptions: this.getOptions(), loading: true, enableAddDateForm: false };
        
        //fetch('api/inventory/')
        //    .then(response => response.json())
        //    .then(data => {
        //        this.setState({ dateOptions: data, loading: false });
        //    });
        this.getOptions = this.getOptions.bind(this);
    }

    getOptions() {
        fetch('api/inventory/')
            .then(response => response.json())
            .then(data => {
                this.setState({ dateOptions: data, loading: false });
            });
    }

    static renderDateOptions(options) {
        
        return (
            <div>
                <Dropdown options={options} placeholder="Select an option" />
               
            </div>
        );
    }
    

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Inventory.renderDateOptions(this.state.dateOptions);
        return (
            <div>
                <h1>Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
                <p></p>
                <InventoryDateAdd onExited={()=>this.getOptions()} />
            </div>
        );
    }
}