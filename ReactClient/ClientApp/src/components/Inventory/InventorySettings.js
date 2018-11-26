import React, { Component} from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';
import { Button, Glyphicon, ButtonGroup, ButtonToolbar, Grid, Row, Col, Modal } from 'react-bootstrap'
var dateFormat = require('dateformat');

class InventoryDateInsertModal extends React.Component {

    handleSaveBtnClick = () => {
        const { columns, onSave, onModalClose } = this.props;
        const newRow = {};
        newRow[columns[0].field] = columns.length + 1;
        newRow[columns[1].field] = this.refs[columns[1].field].value;
        onSave(newRow);
        onModalClose();
    }

    keyPress = (e) => {
        const { columns, onSave } = this.props;
    }

    render() {
        const {
            onModalClose,
            onSave,
            columns
        } = this.props;
        return (
            <div className='modal-content react-bs-table-insert-modal'>
                <div className='modal-header react-bs-table-inser-modal-header'>
                    <h4 className='modal-title'>Create New Inventory Date</h4>
                </div>
                <div className='modal-body'>
                    <div className='form-group' key={columns[0].field}>
                        <input hidden ref={columns[0].field} type='text' defaultValue={0} />
                    </div>
                    <div className='form-group' key={columns[1].field}>
                        <label>{columns[1].name} : </label>
                        <input className="form-control editor edit-text" ref={columns[1].field} type='text' defaultValue={''} />
                    </div>
                </div>
                <div className='modal-footer react-bs-table-inser-modal-footer'>
                    <button className='btn btn-default' onClick={onModalClose}>Leave</button>
                    <button className='btn btn-primary' onClick={() => this.handleSaveBtnClick(columns, onSave)}>Confirm</button>
                </div>
            </div>
        );
    }
}

class InventorySpaceInsertModal extends React.Component {

    handleSaveBtnClick = () => {
        const { columns, onSave, onModalClose } = this.props;
        const newRow = {};
        console.log(columns.length);
        newRow[columns[0].field] = columns.length + 1;
        newRow[columns[1].field] = this.refs[columns[1].field].value;
        // You should call onSave function and give the new row
        onSave(newRow);
        onModalClose();
    }

    keyPress = (e) => {
        const { columns, onSave } = this.props;
        if (e.keyCode === 13) {
           
        }
    }

    render() {
        const {
            onModalClose,
            onSave,
            columns
        } = this.props;
        return (
            <div className='modal-content react-bs-table-insert-modal'>
                <div className='modal-header react-bs-table-inser-modal-header'>
                    <h4 className='modal-title'>Create New Inventory Space</h4>

                </div>
                <div className='modal-body'>
                    <div className='form-group' key={columns[0].field}>
                        <input hidden ref={columns[0].field} type='text' defaultValue={0} />
                    </div>
                    <div className='form-group' key={columns[1].field}>
                        <label>{columns[1].name} : </label>
                        <input className="form-control editor edit-text" ref={columns[1].field} type='text' defaultValue={''} />
                    </div>
                </div>
                <div className='modal-footer react-bs-table-inser-modal-footer'>
                    <button className='btn btn-default' onClick={onModalClose}>Leave</button>
                    <button className='btn btn-primary' onClick={() => this.handleSaveBtnClick(columns, onSave)}>Confirm</button>
                </div>
            </div>
        );
    }
}

export class InventorySettings extends Component {
    displayName = InventorySettings.name
    constructor(props) {
        super(props);
        this.state = {
            dates: this.getDates(),
            spaces: this.getSpaces(),
            showModalDeleteDate: false,
            showModalDeleteSpace: false
        };
        this.getDates = this.getDates.bind(this);
        this.getSpaces = this.getSpaces.bind(this);

        this.handleCloseModalDeleteDate = this.handleCloseModalDeleteDate.bind(this);
        this.handleShowModalDeleteDate = this.handleShowModalDeleteDate.bind(this);
        this.handleCloseModalDeleteSpace = this.handleCloseModalDeleteSpace.bind(this);
        this.handleShowModalDeleteSpace = this.handleShowModalDeleteSpace.bind(this);
    }

    handleCloseModalDeleteDate() {
        this.setState({ showModalDeleteDate: false });
    }

    handleShowModalDeleteDate() {
        this.setState({ showModalDeleteDate: true });
    }

    handleCloseModalDeleteSpace() {
        this.setState({ showModalDeleteSpace: false });
    }

    handleShowModalDeleteSpace() {
        this.setState({ showModalDeleteSpace: true });
    }

        getDates() {
            fetch('api/inventoryDate/')
                .then(response => response.json())

                .then(data => {
                    var tdata = [];
                    data.forEach((date, i) => {
                        var t = { Id: date.Id, Date: dateFormat(date.Date,"dd-mm-yy") };
                        tdata.push(t);
                    }, this);
                    this.setState({ dates: tdata });
                });
        }
        getSpaces() {
            fetch('api/inventorySpace/')
                .then(response => response.json())
                .then(data => {
                    this.setState({ spaces: data});
                });
        }
    createCustomModalDate = (onModalClose, onSave, columns) => {
        const attr = {
            onModalClose, onSave, columns
        };
        return (
            <InventoryDateInsertModal  {...attr} />
        );
    }
    createCustomModalSpace = (onModalClose, onSave, columns) => {
        const attr = {
            onModalClose, onSave, columns
        };
        return (
            <InventorySpaceInsertModal  {...attr} />
        );
    }
    buttonFormatter(cell, row) {
        return (<ButtonToolbar>
            <ButtonGroup>
                <Button onClick={() => this.editAct(row.Id)}>
                    <Glyphicon glyph="pencil" />
                </Button>
                <Button onClick={this.handleShowModalDeleteSpace}>
                    <Glyphicon glyph="trash" />
                </Button>

            </ButtonGroup>
        </ButtonToolbar>);
    }

    render() {
        const dateOptions = {
            insertModal: this.createCustomModalDate
        };
        const spaceOptions = {
            insertModal: this.createCustomModalSpace
        };
        return (
            <div>

                <Modal show={this.state.showModalDeleteDate} onHide={this.handleCloseModalDeleteDate}>
                    <Modal.Header closeButton>
                        <Modal.Title>Delete Inventory Date</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <h4>Are you sure?</h4>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button onClick={this.handleCloseModalDeleteDate}>No</Button>
                        <Button className='btn btn-primary' onClick={this.handleCloseModalDeleteDate}>Sure</Button>
                    </Modal.Footer>
                </Modal>

                <Modal show={this.state.showModalDeleteSpace} onHide={this.handleCloseModalDeleteSpace}>
                    <Modal.Header closeButton>
                        <Modal.Title>Delete Inventory Space</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <h4>Are you sure?</h4>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button onClick={this.handleCloseModalDeleteDate}>No</Button>
                        <Button className='btn btn-primary' onClick={this.handleCloseModalDeleteDate}>Sure</Button>
                    </Modal.Footer>
                </Modal>

            <Grid>
                <Row className="show-grid" height="50px" >
                    <Col >
                        <p><h1>Inventory Setting</h1></p>
                    </Col>
                </Row>
                <Row className="show-grid">
                    <Col md={6} mdPush={6}>
                        Dates
                <BootstrapTable data={this.state.dates} options={dateOptions} renderAlert={false} insertRow width="40%" >
                    <TableHeaderColumn dataField='Id' isKey hidden></TableHeaderColumn>
                    <TableHeaderColumn dataField='Date'>Date</TableHeaderColumn>
                    <TableHeaderColumn dataField="button" width="100px" dataFormat={this.buttonFormatter.bind(this)}>Actions</TableHeaderColumn>
                        </BootstrapTable>
                    </Col>

                    <Col md={6} mdPull={6}>
                        Spaces
                        <BootstrapTable data={this.state.spaces} options={spaceOptions} renderAlert={false} insertRow>
                             <TableHeaderColumn dataField='Id' isKey hidden></TableHeaderColumn>
                            <TableHeaderColumn dataField='Name'>Space Name</TableHeaderColumn>
                            <TableHeaderColumn dataField="button" width="100px" dataFormat={this.buttonFormatter.bind(this)}>Actions</TableHeaderColumn>
                        </BootstrapTable>
                    </Col>
                </Row>
                </Grid>
            </div>
        );
    }
}