import React from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';


//const products = [];

//function addProducts(quantity) {
//    if (this.props.match.params.mode !== "add") {
//        fetch('api/inventoryBody/' + this.props.match.params.id)
//            .then(response => response.json())
//            .then(data => {
//                this.setState({ tableBody: data });
//            });
//    }
//    else {
//        this.setState({ tableBody: [] });
//    }
//}

//addProducts(5);


class CustomInsertModal extends React.Component {

    handleSaveBtnClick = () => {
        const { columns, onSave } = this.props;
        const newRow = {};
        columns.forEach((column, i) => {
            console.log(this.refs[column.field].value);
            newRow[column.field] = this.refs[column.field].value;
        }, this);
        // You should call onSave function and give the new row
        onSave(newRow);
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
                    <h4 className='modal-title'>Custom Insert Modal</h4>
                </div>
                <div className='modal-body'>
                    <div className='form-group' key={columns[0].field}>
                        <label>{columns[0].name} : </label>
                        <input className="form-control editor edit-text" ref={columns[0].field} type='text' defaultValue={''} />
                        
                    </div>
                    <div className='form-group' key={columns[1].field}>
                        <label>{columns[1].name} : </label>
                        <input disabled className="form-control editor edit-text" ref={columns[1].field} type='text' defaultValue={''} />

                    </div>
                    <div className='form-group' key={columns[2].field}>
                        <label>{columns[2].name} : </label>
                        <input className="form-control editor edit-text" ref={columns[2].field} type='text' defaultValue={''} />

                    </div>
                    {/*

                        columns.map((column, i) => {
                            const {
                                editable,
                                format,
                                field,
                                name,
                                hiddenOnInsert
                            } = column;

                            if (hiddenOnInsert) {
                                // when you want same auto generate value
                                // and not allow edit, for example ID field
                                return null;
                            }
                           // const error = validateState[field] ?
                           //     (<span className='help-block bg-danger'>{validateState[field]}</span>) :
                          //      null;
                            return (
                                <div className='form-group' key={field}>
                                    <label>{name} : </label>
                                    <input className="form-control editor edit-text" ref={field} type='text' defaultValue={''} />
                                   //{error}
                                </div>
                            );
                        })
                   */ }
                </div>
                <div>
                    <button className='btn btn-danger' onClick={onModalClose}>Leave</button>
                    <button className='btn btn-success' onClick={() => this.handleSaveBtnClick(columns, onSave)}>Confirm</button>
                </div>
            </div>
        );
    }
}


export  class InventoryBodyTable extends React.Component {

    createCustomModal = (onModalClose, onSave, columns) => {
        const attr = {
            onModalClose, onSave, columns
        };
        return (
            <CustomInsertModal  {...attr} />
        );
    }

    render() {
        const options = {
            insertModal: this.createCustomModal
        };
        return (
            <BootstrapTable data={this.props.data} options={options} renderAlert={false} insertRow>
                <TableHeaderColumn dataField='id' hidden></TableHeaderColumn>
                <TableHeaderColumn dataField='number'>Row</TableHeaderColumn>
                <TableHeaderColumn dataField='ean' isKey={true}>Product EAN</TableHeaderColumn>
                <TableHeaderColumn dataField='name'>Product Name</TableHeaderColumn>
                <TableHeaderColumn dataField='count'>Product Count</TableHeaderColumn>
            </BootstrapTable>
        );
    }
}