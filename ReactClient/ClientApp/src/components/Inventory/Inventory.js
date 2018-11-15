import React, { Component } from 'react';
import Select from 'react-select'
import 'react-dropdown/style.css'
import InventoryDateAdd  from './InventoryDateAdd';
import { Button } from 'react-bootstrap'

export class Inventory extends Component {
    displayName = Inventory.name

    constructor(props) {
        super(props);
        this.state = {
            dateOptions: this.getDateOptions(), dateLoading: true, enableAddDateForm: false, selectDateId: 0,
            headOptions: [], headLoading: true, enableAddHeadForm: false, selectHeadId: 0
        };
        
        this.dateChange = this.dateChange.bind(this);
        this.getDateOptions = this.getDateOptions.bind(this);
        this.deleteDate = this.deleteDate.bind(this);

        this.headChange = this.headChange.bind(this);
        this.getHeadOptions = this.getHeadOptions.bind(this);
        this.deleteHead = this.deleteHead.bind(this);
    }

    getDateOptions() {
        fetch('api/inventoryDate/')
            .then(response => response.json())
            .then(data => {
                this.setState({ dateOptions: data, dateLoading: false });
            });
            
    }

    dateChange = (v) => {
        this.setState({ selectDateId: v.value, headOptions: this.getHeadOptions(v.value) });
    }

    deleteDate(){
        var id = this.state.selectDateId;
        fetch('api/inventoryDate/' + id,
            {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                //  body: JSON.stringify(id )
            });
    }

    /////////////
    getHeadOptions(id) {
        fetch('api/inventoryHead/' + id)
            .then(response => response.json())
            .then(data => {
                this.setState({ headOptions: data, headLoading: false });
            });

    }

    headChange = (v) => {
        this.setState({ selectHeadId: v.value });
    }

    deleteHead() {
        var id = this.state.selectHeadId;
        fetch('api/inventoryDate/' + id,
            {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
            });
    }
    //////////////

    render() {
        let dateContents = this.state.dateLoading
            ? <p><em>Loading dates...</em></p>
            : <div>
                <Select options={this.state.dateOptions} onChange={this.dateChange} placeholder="Select an option"  />
            </div>;

        let headContents = this.state.headLoading
            ? <p><em>Loading heads...</em></p>
            : <div>
                <Select options={this.state.headOptions} onChange={this.headChange} placeholder="Select an option" />
            </div>;

        return (
            <div>
                <h1>Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {dateContents}
                <Button onClick={() => this.deleteDate()}       >
                    Delete Inventory Date
                </Button>
                <InventoryDateAdd isEdit={false} onExited={() => this.getDateOptions()} />

                {this.state.headLoading
                    ? <p><em>Loading heads...</em></p>
                    : <div>
                        <Select options={this.state.headOptions} onChange={this.headChange} placeholder="Select an option" />
                    </div>
                }
               
                <Button onClick={() => this.deleteHead()}       >
                    Delete Inventory Head
                </Button>
                <InventoryDateAdd  onExited={() => this.getHeadOptions()} />

            </div>
        );
    }
}