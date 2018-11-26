import React, { Component } from 'react';
import Select from 'react-select'
import 'react-dropdown/style.css'
import { Button, Glyphicon, ButtonGroup, ButtonToolbar, Modal } from 'react-bootstrap'
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';
import './react-bootstrap-table-all.min.css';


export class Inventory extends Component {
    displayName = Inventory.name

    constructor(props) {
        super(props);
        this.state = {
            dateOptions: this.getDateOptions(), dateLoading: true, selectDateId: 0,
            headData: [], headLoading: true,
             showModalDeleteDate: false
        };
        
        this.dateChange = this.dateChange.bind(this);
        this.getDateOptions = this.getDateOptions.bind(this);
        this.getHeadData = this.getHeadData.bind(this);
        this.viewAct = this.viewAct.bind(this);
        this.editAct = this.editAct.bind(this);
        this.deleteAct = this.deleteAct.bind(this);

        this.handleCloseModalDeleteDate = this.handleCloseModalDeleteDate.bind(this);
        this.handleShowModalDeleteHead = this.handleShowModalDeleteHead.bind(this);
    }

    getDateOptions() {
        fetch('api/inventoryDate/')
            .then(response => response.json())
            .then(data => {
                var tdata = [];
                data.forEach((date, i) => {
                    var t = { value : date.Id, label : date.Date };
                    tdata.push(t);
                }, this);
                this.setState({ dateOptions: tdata, dateLoading: false });
            });
    }
    dateChange = (v) => {
        this.setState({ selectDateId: v.value, headData: this.getHeadData(v.value) });
    }
    getHeadData(id) {
        const name = [
            "Jonson",
            "Peterson",
            "Deelan",
            "Mitty",
            "Adelwiess",
            "Bournly",
            "McBahman",
            "Cohen",
            "Petrov",
            "Duglas",
            "Kein",
            "Anderson",
            "Hopkins",
            "Rihter"
        ];
        fetch('api/inventoryHead/' + id)
            .then(response => response.json())
            .then(data => {
                var tdata = [];
                data.forEach((head, i) => {
                    head.PersonFromWarehouseName = name[i*2];
                    head.PersonFromOfficeName = name[(i*2)+1];
                    
                }, this);
                this.setState({ headData: data, headLoading: false });
            });

    }

    addAct() {
        var win = window.open("/inventoryAct/add", '_blank');
        win.focus();
    }
    viewAct(id)
    {
        var win = window.open("/inventoryAct/view/"+id, '_blank');
        win.focus();
    }
    editAct(id) {
        var win = window.open("/inventoryAct/edit/"+id, '_blank');
        win.focus();
    }
    deleteAct(id) {
       
    }
    handleCloseModalDeleteDate() {
        this.setState({ showModalDeleteDate: false });
    }

    handleShowModalDeleteHead() {
        this.setState({ showModalDeleteDate: true });
    }


    buttonFormatter(cell, row) {
         return (<ButtonToolbar>
             <ButtonGroup>
                 <Button onClick={()=>this.viewAct(row.Id)}>
                     <Glyphicon glyph="search" />
                 </Button>
                 <Button onClick={()=>this.editAct(row.Id)}>
                     <Glyphicon glyph="pencil" />
                 </Button>
                 <Button onClick={()=>this.handleShowModalDeleteHead()}>
                     <Glyphicon glyph="trash" />
                 </Button>
             </ButtonGroup>
         </ButtonToolbar>);
}
    
    render() {
       

        return (
            <div>
                <h1>Inventory</h1>
                <Modal show={this.state.showModalDeleteDate} onHide={this.handleCloseModalDeleteDate}>
                    <Modal.Header closeButton>
                        <Modal.Title>Delete Inventory Act</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <h4>Are you sure?</h4>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button onClick={this.handleCloseModalDeleteDate}>No</Button>
                        <Button className='btn btn-primary' onClick={this.handleCloseModalDeleteDate}>Sure</Button>
                    </Modal.Footer>
                </Modal>
                
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
                            <TableHeaderColumn dataField='Number' width='100' >Number</TableHeaderColumn>
                            <TableHeaderColumn dataField='InventorySpaceName'>Inventory Space</TableHeaderColumn>
                            <TableHeaderColumn dataField='PersonFromWarehouseName'>Person From Warehouse</TableHeaderColumn>
                            <TableHeaderColumn dataField='PersonFromOfficeName'>Person From Office</TableHeaderColumn>
                            
                            <TableHeaderColumn dataField="button" width='150' dataFormat={this.buttonFormatter.bind(this)}>Actions</TableHeaderColumn>
                        </BootstrapTable>
                }

            </div>
        );
    }
}