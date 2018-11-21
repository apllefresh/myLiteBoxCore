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
        const { columns, onSave, onModalClose } = this.props;
        const newRow = {};
        columns.forEach((column, i) => {
            console.log(this.refs[column.field].value);
            newRow[column.field] = this.refs[column.field].value;
        }, this);
        // You should call onSave function and give the new row
        onSave(newRow);
        onModalClose();
    }

    keyPress=(e)=> {
        const { columns, onSave } = this.props;
        if (e.keyCode === 13) {
            fetch('http://localhost:10220/api/ProductSearchByEan/' + e.target.value)
                .then(response => response.json())
                .then(data => {
                    this.refs[columns[3].field].value = data;
                }
            ).catch(er => {
                this.refs[columns[3].field].value = "";
            });
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
                    <h4 className='modal-title'>Custom Insert Modal</h4>
                    
                </div>
                <div className='modal-body'>
                    <div className='form-group' key={columns[0].field}>
                        <input hidden ref={columns[0].field} type='text' defaultValue={0} />
                    </div>
                    <div className='form-group' key={columns[1].field}>
                        <input hidden ref={columns[1].field} type='text' defaultValue={0} />
                    </div>
                    <div className='form-group' key={columns[2].field}>
                        <label>{columns[2].name} : </label>
                        <input className="form-control editor edit-text" onKeyDown={this.keyPress} onChange={this.handleChange} ref={columns[2].field} type='text' defaultValue={''} />
                        
                    </div>
                    <div className='form-group' key={columns[3].field}>
                        <label>{columns[3].name} : </label>
                        <input disabled className="form-control editor edit-text" ref={columns[3].field} type='text' />

                    </div>
                    <div className='form-group' key={columns[4].field}>
                        <label>{columns[4].name} : </label>
                        <input className="form-control editor edit-text" ref={columns[4].field} type='text' defaultValue={''} />

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
                <TableHeaderColumn dataField='Id' hidden></TableHeaderColumn>
                <TableHeaderColumn dataField='RowNumber'>Row</TableHeaderColumn>
                <TableHeaderColumn dataField='Ean' isKey={true}>Product EAN</TableHeaderColumn>
                <TableHeaderColumn dataField='Name'>Product Name</TableHeaderColumn>
                <TableHeaderColumn dataField='Count'>Product Count</TableHeaderColumn>
            </BootstrapTable>
        );
    }
}