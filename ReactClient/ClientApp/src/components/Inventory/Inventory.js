import React, { Component } from 'react';
import Select from 'react-select'
import 'react-dropdown/style.css'
import InventoryDateAdd from './InventoryDateAdd';
import { Button } from 'react-bootstrap'
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';


export class Inventory extends Component {
    displayName = Inventory.name

    constructor(props) {
        super(props);
        this.state = {
            dateOptions: this.getDateOptions(), dateLoading: true, enableAddDateForm: false, selectDateId: 0,
            headOptions: [], headLoading: true, enableAddHeadForm: false, selectHeadId: 0,
            bodyOptions: [], bodyLoading: true
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
        this.setState({ selectHeadId: v.value, bodyOptions: this.getBodyOptions(v.value) });
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


    getBodyOptions(id) {
        fetch('api/inventoryBody/' + id)
            .then(response => response.json())
            .then(data => {
                this.setState({ bodyOptions: data, bodyLoading: false });
            });

    }

    /////////////////////////

    render() {
        return (
            <div>
                <h1>Inventory</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {
                    this.state.dateLoading
                    ? <p><em>Loading dates...</em></p>
                        : <div>
                            <Select options={this.state.dateOptions} onChange={this.dateChange} placeholder="Select an option" />
                            <Button onClick={() => this.deleteDate()} > Delete Inventory Date </Button>
                            <InventoryDateAdd isEdit={false} onExited={() => this.getDateOptions()} />
                        </div>
                }
                

                {
                    this.state.headLoading
                    ? <p><em>...</em></p>
                    : <div>
                        <Select options={this.state.headOptions} onChange={this.headChange} placeholder="Select an option" />
                        <Button onClick={() => this.deleteHead()}> Delete Inventory Head </Button>
                     </div>
                }

                { 
                    this.state.bodyLoading ?
                        <p><em>dd</em></p>
                        : <BootstrapTable data={this.state.bodyOptions} striped hover>
                            <TableHeaderColumn isKey dataField='id' >Product ID</TableHeaderColumn>
                            <TableHeaderColumn dataField='price'>Row Number</TableHeaderColumn>
                            <TableHeaderColumn dataField='name'>Product Name</TableHeaderColumn>
                            <TableHeaderColumn dataField='price'>Product Price</TableHeaderColumn>
                            <TableHeaderColumn dataField='price'>Product Count</TableHeaderColumn>
                        </BootstrapTable>
                }

            </div>
        );
    }
}