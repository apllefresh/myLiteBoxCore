import React, { Component } from 'react';
import Select from 'react-select'
import 'react-dropdown/style.css'
import { Button, Glyphicon, ButtonGroup, ButtonToolbar } from 'react-bootstrap'
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';

export class Inventory extends Component {
    displayName = Inventory.name

    constructor(props) {
        super(props);
        this.state = {
            dateOptions: this.getDateOptions(), dateLoading: true, selectDateId: 0,
            headData: [], headLoading: true
        };
        
        this.dateChange = this.dateChange.bind(this);
        this.getDateOptions = this.getDateOptions.bind(this);
        this.getHeadData = this.getHeadData.bind(this);
        this.viewAct = this.viewAct.bind(this);
        this.editAct = this.editAct.bind(this);
        this.deleteAct = this.deleteAct.bind(this);
    }

    getDateOptions() {
        fetch('api/inventoryDate/')
            .then(response => response.json())
            .then(data => {
                this.setState({ dateOptions: data, dateLoading: false });
            });
            
    }
    dateChange = (v) => {
        this.setState({ selectDateId: v.value, headData: this.getHeadData(v.value) });
    }
    getHeadData(id) {
        fetch('api/inventoryHead/' + id)
            .then(response => response.json())
            .then(data => {
                this.setState({ headData: data, headLoading: false });
            });

    }

    viewAct()
    {
        var win = window.open("/inventoryAct/?mode=add", '_blank');
        win.focus();
    }
    editAct(id) {
        var win = window.open("/inventoryAct/?mode=add&id="+id, '_blank');
        win.focus();
    }
    deleteAct(id) {
       
    }

    buttonFormatter(cell, row) {
         return (<ButtonToolbar>
             <ButtonGroup>
                 <Button onClick={this.viewAct}>
                     <Glyphicon glyph="search" />
                 </Button>
                 <Button onClick={()=>this.editAct(row.Id)}>
                     <Glyphicon glyph="pencil" />
                 </Button>
                 <Button onClick={() => this.deleteAct(row.Id)}>
                     <Glyphicon glyph="trash" />
                 </Button>
                 
             </ButtonGroup>
         </ButtonToolbar>);
}
    
    render() {
       

        return (
            <div>
                <h1>Inventory</h1>
                <Glyphicon glyph="pencil" /> 
                <p>This component demonstrates fetching data from the server.</p>
                {
                    this.state.dateLoading
                    ? <p><em>Loading dates...</em></p>
                        : <div>
                            <Select options={this.state.dateOptions} onChange={this.dateChange} placeholder="Select an option" />
                        </div>
                }

                <Button hidden={this.state.dateLoading}> Add inventory act </Button>
                { 
                    this.state.bodyLoading ?
                        <p><em>dd</em></p>
                        : <BootstrapTable data={this.state.headData} striped hover>
                            <TableHeaderColumn dataField='Id' isKey hidden >Product ID</TableHeaderColumn>
                            <TableHeaderColumn dataField='Number'>Number</TableHeaderColumn>
                            <TableHeaderColumn dataField='InventorySpaceName'>InventorySpaceId</TableHeaderColumn>
                            <TableHeaderColumn dataField='PersonFromWarehouseName'>PersonFromWarehouseId</TableHeaderColumn>
                            <TableHeaderColumn dataField='PersonFromOfficeName'>PersonFromOfficeId</TableHeaderColumn>
                            
                            <TableHeaderColumn dataField="button" dataFormat={this.buttonFormatter.bind(this)}>Buttons</TableHeaderColumn>
                        </BootstrapTable>
                }

            </div>
        );
    }
}