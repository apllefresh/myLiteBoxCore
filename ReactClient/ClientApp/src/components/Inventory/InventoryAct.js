import React, { Component } from 'react';
import Select from 'react-select'
import 'react-dropdown/style.css'
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';

export class InventoryAct extends Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            mode: this.props.match.params.mode, id: this.props.match.params.id
            , dateOptions: this.getDateOptions(), selectDateId:0
        };
       

        this.getDateOptions = this.getDateOptions.bind(this);
        this.dateChange = this.dateChange.bind(this);
       
    }

   

    getDateOptions() {
        fetch('api/inventorySpace/')
            .then(response => response.json())
            .then(data =>
            {
                var tdata = [];
                data.map((t, index) => tdata.push({ label: t.Name, value: t.Id }));
                this.setState({ dateOptions: tdata, dateLoading: false });
            });

    }
    dateChange = (v) => {
        this.setState({ selectDateId: v.value });
    }
   
    render() {
        return (
            <div>
                { 
                    (this.state.mode === "view") ?
                        <Select options={this.state.dateOptions} onChange={this.dateChange} placeholder="Select an option" />
                        : <p></p>
                        }
                        
                {this.state.mode}
                <p>{this.state.id}</p>
                
            </div>
        );
    }
}

