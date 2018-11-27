import React, { Component } from 'react';
import Select from 'react-select'
import 'react-dropdown/style.css'
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';
import { InventoryBodyTable } from './InventoryBodyTable';
import { Button, Glyphicon, ButtonGroup, ButtonToolbar, Grid, Row, Col, Modal } from 'react-bootstrap'

export class InventoryResult extends Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            mode: this.props.match.params.mode, id: this.props.match.params.id
            , spaceOptions: this.getSpaceOptions(), selectSpaceId: 0
            , data: []
            , value: '', valueEan: ''
        };


        this.getSpaceOptions = this.getSpaceOptions.bind(this);
        this.spaceChange = this.spaceChange.bind(this);

        this.getTableBody = this.getTableBody.bind(this);


    }

    getSpaceOptions() {
        fetch('api/inventoryDate/')
            .then(response => response.json())
            .then(data => {
                var tdata = [];
                data.map((t, index) => tdata.push({ label: t.Date, value: t.Id }));
                this.setState({ spaceOptions: tdata });
            });
    }
    spaceChange = (v) => {
        this.setState({ selectSpaceId: v.value });
        this.getTableBody();
    }

    getTableBody() {
        var dat = [
            {
                Id : 1
                ,Department : "MKO"
                ,GoodGroup  : "Meat"
                ,CountFact  : 10
                ,CountReal  :10
                ,CountDiff  :0
                ,SumFact    :300
                ,SumReal    :300
                , SumDiff: 0
                ,Date : "2018-01-01"
    },
            {
                Id : 2
                , Department : "MKO"
                , GoodGroup  : "Milk"
                , CountFact  :16
                , CountReal  :17
                , CountDiff  :1
                , SumFact    :160
                , SumReal    :170
                , SumDiff: 10
                , Date: "2018-01-01"
    },
            {
                Id : 3
                , Department : "MKO"
                , GoodGroup  : "Eggs"
                , CountFact  :33
                , CountReal  :32
                , CountDiff  :-1
                , SumFact    :66
                , SumReal    :64
                , SumDiff: -2
                , Date: "2018-01-01"
    },
            {
                Id : 4
                , Department : "BKO"
                , GoodGroup  : "Spices"
                , CountFact  :300
                , CountReal  :300
                , CountDiff  :0
                , SumFact    :1200
                , SumReal    :1200
                , SumDiff: 0
                , Date: "2018-01-01"
    },
            {
                Id : 5
                , Department : "BKO"
                , GoodGroup  : "Flower"
                , CountFact  :52
                , CountReal  :52
                , CountDiff  :0
                , SumFact    :1235
                , SumReal    :1235
                , SumDiff: 0
                , Date: "2018-01-01"
    }
        ];
        this.setState({ data: dat });
        console.log(this.state.data);
//fetch('api/inventoryResult/')
//        .then(response => response.json())
        //    .then(data => {
                    
        //            this.setState({ data: data });
        //        });
    }


    render() {


        return (
            <Grid>
                <Row className="show-grid" style={{ height: '100px' }} >
                    <Col md={5} mdPush={3} >
                        <p><h1> Inventory Result</h1></p>

                    </Col>
                </Row>

                <Row className="show-grid" style={{ height: '150px' }} >
                    <Col md={3} >
                        <h4>Inventory Date</h4>
                        <Select options={this.state.spaceOptions} onChange={this.spaceChange} placeholder="Select space" />
                    </Col>
                    <Col md={3} >
                        <h4>Deaprtment</h4>
                        <Select options={this.state.spaceOptions} onChange={this.spaceChange} placeholder="Select deaprtment" />
                    </Col>
                    <Col md={3} >
                        <h4>Product Group</h4>
                        <Select options={this.state.spaceOptions} onChange={this.spaceChange} placeholder="Select group" />
                    </Col>
                   
                </Row>


                <Row className="show-grid" style={{ height: '250px' }} >
                    <Col  >
                        <BootstrapTable data={this.state.data} renderAlert={false} >
                            <TableHeaderColumn dataField='Id' isKey={true} hidden></TableHeaderColumn>
                            <TableHeaderColumn dataField='Date'>Date</TableHeaderColumn>
                            <TableHeaderColumn dataField='Department' >Department</TableHeaderColumn>
                            <TableHeaderColumn dataField='GoodGroup'>Good Group</TableHeaderColumn>
                            <TableHeaderColumn dataField='CountFact'>Count Fact</TableHeaderColumn>
                            <TableHeaderColumn dataField='CountReal'>Count Real</TableHeaderColumn>
                            <TableHeaderColumn dataField='CountDiff'>Count Diff</TableHeaderColumn>
                            <TableHeaderColumn dataField='SumFact'>Sum Fact</TableHeaderColumn>
                            <TableHeaderColumn dataField='SumReal'>Sum Real</TableHeaderColumn>
                            <TableHeaderColumn dataField='SumDiff'>Sum Diff</TableHeaderColumn>
                        </BootstrapTable>
                    </Col>
                </Row>


                <Row className="show-grid" style={{ height: '100px' }} >
                    <Col md={1} mdPush={10} >
                        <Button className='btn btn-primary' onClick={this.handleCloseModalDeleteDate}>Calculate</Button>
                    </Col>
                    <Col md={1} mdPush={10} >
                        
                        <Button className='btn btn-success' onClick={this.handleCloseModalDeleteDate}>Save</Button>
                    </Col>
                </Row>
            </Grid>
        );
    }
}