import React, { Component } from 'react';
import Select from 'react-select'
import 'react-dropdown/style.css'
import InventoryDateAdd  from './InventoryDateAdd';
import { Button } from 'react-bootstrap'

export class Inventory extends Component {
    displayName = Inventory.name

    constructor(props) {
        super(props);
        this.state = { dateOptions: this.getOptions(), loading: true, enableAddDateForm: false, selectDateId: 0 };
        
        this.handleChange = this.handleChange.bind(this);
        this.getOptions = this.getOptions.bind(this);
        this.deleteDate = this.deleteDate.bind(this);
    }

    getOptions() {
        fetch('api/inventory/')
            .then(response => response.json())
            .then(data => {
                this.setState({ dateOptions: data, loading: false });
            });
            
    }

    handleChange =(v)=> {
       // console.log(v.value);
        this.setState({ selectDateId: v.value });
    }

    deleteDate(){
        var id = this.state.selectDateId;
        fetch('api/inventory/' + id,
            {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                //  body: JSON.stringify(id )
            });
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : <div>
                <Select options={this.state.dateOptions} onChange={this.handleChange} placeholder="Select an option"  />
                
            </div>;
        return (
            <div>
                <h1>Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
                <Button onClick={() => this.deleteDate()}       >
                    Delete Inventory Date
                </Button>
                <p></p>
                <InventoryDateAdd isEdit={false}  onExited={() => this.getOptions()} />
                
            </div>
        );
    }
}