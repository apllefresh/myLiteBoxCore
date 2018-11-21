import React, { Component } from 'react';
import Select from 'react-select'
import 'react-dropdown/style.css'
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';
import { InventoryBodyTable } from './InventoryBodyTable';


export class InventoryAct extends Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            mode: this.props.match.params.mode, id: this.props.match.params.id
            , spaceOptions: this.getSpaceOptions(), selectSpaceId: 0
            , tableBody: this.getTableBody()
            , value: '', valueEan:''
        };
       

        this.getSpaceOptions = this.getSpaceOptions.bind(this);
        this.spaceChange = this.spaceChange.bind(this);

        this.getTableBody = this.getTableBody.bind(this);

        this.handleChange = this.handleChange.bind(this);
        this.keyPress = this.keyPress.bind(this);
    }

  




    getSpaceOptions() {
        fetch('api/inventorySpace/')
            .then(response => response.json())
            .then(data =>
            {
                var tdata = [];
                data.map((t, index) => tdata.push({ label: t.Name, value: t.Id }));
                this.setState({ spaceOptions: tdata, dateLoading: false });
            });
    }
    spaceChange = (v) => {
        this.setState({ selectSpaceId: v.value });
    }

    getTableBody() {
        if (this.props.match.params.mode !== "add") {
            fetch('api/inventoryBody/' + this.props.match.params.id)
                .then(response => response.json())
                .then(data => {
                    this.setState({ tableBody: data });
                });
        }
        else {
            this.setState({ tableBody: [] });
        }
    }


    handleChange(e) {
        this.setState({ value: e.target.value });
    }

    keyPress(e) {
        if (e.keyCode === 13) {
            this.setState({ valueEan: e.target.value });
        }
    }

    customNameField = (column, attr, editorClass, ignoreEditable) => {
        return (
            <input placeholder="Product EAN" className="form-control editor edit-text" value={this.state.value} onKeyDown={this.keyPress} onChange={this.handleChange}  />
        );
    }
    customField = (column, attr, editorClass, ignoreEditable) => {
        return (
            <input disabled placeholder="Product Name" className="form-control editor edit-text" value={this.state.valueEan} />
        );
    }

    render() {
       

        return (
            <div>
                { 
                    (this.state.mode === "view") ?
                        <Select options={this.state.spaceOptions} onChange={this.spaceChange} placeholder="Select an option" />
                        : <p></p>
                        }
                        
                
               
                <InventoryBodyTable data={this.state.tableBody}  > </InventoryBodyTable>
            </div>
        );
    }
}



