import { useState } from 'react';
import list from './To_Do_List.module.css';
import search from '../../assets/search.png'
import tasks from '../../assets/house.png';
import assign from '../../assets/user.png';
import complete from '../../assets/check.png';
import all from '../../assets/infinity.png';
import my_day from '../../assets/brightness.png';
import planned from '../../assets/calendar.png';
import important from '../../assets/star.png';
import user from '../../assets/add-user (1).png';
import deleteList from '../../assets/delete.png';
import editList from '../../assets/icons8-edit-64.png';
import Add from '../AddnEdit/Add';
import Edit from '../AddnEdit/Edit'
import './popup.css'

//import search from '../../assets/search.png'

function To_Do_List() {
    const [ButtonPopup, setButtonPopup] = useState(false);
    const [ButtonPopupEdit, setButtonPopupEdit] = useState(false);
    let [UpdateToDoList, setUpdateToDoList] = useState([]);

    let [ToDoList, setToDoList] = useState([]);


    let [ToDoListEnter, setToDoListEnter] = useState({
        title: '',
        description: '',
        dueDate:'',
        priority:''
    });

    const handleChange = e => {
        const { name, value } = e.target;
        setToDoListEnter(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    const handleChangeUpdate = e => {
        const { name, value } = e.target;
        setUpdateToDoList(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    const updateList = (data) => {
        setUpdateToDoList(data)
        setButtonPopupEdit(true)
    }

    const addTasks = () => {
        setToDoListEnter('');
        setToDoListEnter('');
        setButtonPopup(true)

    }

    const AddToDoList = () => {
        console.log(ToDoListEnter);
        
        // for (var list = 0; list < ToDoList.length; list++) {
        //     if (ToDoList.filter(item => item.id === list + 1).length === 0) {
        //         ToDoListEnter.id = list + 1
        //         ToDoList.push(ToDoListEnter);
        //         localStorage.setItem('ToDoList', JSON.stringify(ToDoList))
        //         alert('Successfully Added to List')
        //         return setButtonPopup(false)
        //     }
        // }

        // ToDoListEnter.id = ToDoList.length + 1
        // ToDoList.push(ToDoListEnter)
        // localStorage.setItem('ToDoList', JSON.stringify(ToDoList))
        alert('Successfully Added to List')
        return setButtonPopup(false)


    }

    const DeleteToDoList = (idx) => {
        setToDoList(ToDoList.filter((todo) => todo.id !== idx))
        return alert('Deleted')
    }

    const updateToDoList = () => {
        ToDoList[UpdateToDoList.id - 1] = UpdateToDoList
        return setButtonPopupEdit(false)
    }

    let addPopUp = (
        <div className="main">
            <div className="header">
                <h1>Add New Task</h1>
            </div>
            <div className="form-group">
                <label>Title</label>
                <input type="text" name="title" value={ToDoListEnter.title} onChange={handleChange} className="form-control" />
            </div>
            <div className="form-group">
                <label>Description</label>
                <textarea name="description" id="description" cols="30" rows="10" value={ToDoListEnter.description} onChange={handleChange} className="form-control"></textarea>
            </div>
            <div className="form-group">
                <label>Due Date</label>
                <input type="date" name="title" value={ToDoListEnter.dueDate} onChange={handleChange} className="form-control" />
            </div>
            <div className="form-group">
                <label>Priority</label>
                <select className="form-control" name='priority' onChange={handleChange}>
                    <option selected disabled>Select priority</option>
                    <option value="Low">Low</option>
                    <option value="Medium">Medium</option>
                    <option value="High">High</option>
                </select>
            </div>
            <div className="form-group">
                <button type="submit" className="btn" onClick={AddToDoList}>Add</button>
            </div>
        </div>
    );

    let editPopUp = (
        <div className="main">
            <div className="header" key={UpdateToDoList.id}>
                <h1>Edit Task</h1>
            </div>
            <div className="form-group">
                <label>Title</label>
                <input type="text" name="title" value={UpdateToDoList.title} onChange={handleChangeUpdate} className="form-control" />
            </div>
            <div className="form-group">
                <label>Description</label>
                <textarea name="description" id="description" cols="30" rows="10" className="form-control" value={UpdateToDoList.description} onChange={handleChangeUpdate}></textarea>
            </div>
            <div className="form-group">
                <button type="submit" className="btn" onClick={updateToDoList}>Update</button>
            </div>
        </div>
    );

    return (
        <body div className={list.list}>
            <div className={list.content}>
                <div className={list.left}>
                    <div className={list.nameHeader}>
                        <label><span>DM</span> <p>Dipono Manasoe</p></label>
                        
                    </div>
                </div>
                <div className={list.right}>
                    <div className={list.rightHeader}>
                        <h2>Entertainment List</h2>
                        <div className={list.user}>
                            <img src={user} alt={user} className={list.userLog} />
                            <label><p>...</p></label>
                        </div>
                    </div>
                    <div className={list.addTasks}>
                        <label onClick={addTasks}> + </label>
                        <p onClick={addTasks}>Add a Task</p>
                    </div>

                    <Add trigger={ButtonPopup} setTrigger={setButtonPopup}>
                        {addPopUp}
                    </Add>

                    <div className={list.entList}>

                        {ToDoList.map((toDoList, idx, index) => (
                            <div className={list.formList} key={idx}>
                                <div className={list.entertainmentList}>
                                    <h3>{toDoList.title}</h3>
                                    <p>{toDoList.description}</p>
                                </div>
                                <div className={list.buttons}>
                                    <img src={editList} alt={editList} className={list.controlForm}
                                        onClick={() => updateList(toDoList)} />
                                    <img src={deleteList} alt={deleteList} className={list.controlForm}
                                        onClick={() => DeleteToDoList(toDoList.id)} />
                                </div>
                            </div>
                        ))}
                        {<Edit triggerEdit={ButtonPopupEdit} setTriggerEdit={setButtonPopupEdit}>
                            {editPopUp}
                        </Edit>}
                    </div>
                </div>
            </div>
        </body>
    )
}

export default To_Do_List;