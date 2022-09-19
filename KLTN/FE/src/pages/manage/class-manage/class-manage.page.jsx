import './class-manage.css'
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import { useHistory } from 'react-router-dom';
import DataTableComponent from '../../../components/datatable/datatable.component';
const data = [
    {
      id: 1,
      title: "Lop 10A1",
      image:
        "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
    },
    {
      id: 2,
      title: "Lop 11A2",
      image:
        "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
    },
    {
      id: 3,
      title: "Lop 10A1",
      image:
        "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
    },
    {
      id: 4,
      title: "Lop 10A2",
      image:
        "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
    },
    {
      id: 5,
      title: "Lop 10A3",
      image:
        "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
    },
    {
      id: 6,
      title: "Nhut Anh",
      image:
        "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
    },
  ];
const ClassManagePage = () => {
    const {location} = useHistory();
    const mySwal = withReactContent(Swal);
    const openEditModal = (row) => {
      mySwal.fire({
        title: 'Edit subject',
        html: <div>Are you sure?</div>
      })
    }
    const openDeleteModal = (row) => {
      mySwal.fire({
        title: 'Delete'
      })
    }
    const openAddModal = () => {
      mySwal.fire({
        title: 'Add subject',
        html: <div>This is add modal</div>
      })
    }
    return ( <div className="class-manage">
         <DataTableComponent
         rows={data}
         headerTitle={"Class manager"}
         idColumn="id"
         imageColumns="image"
         isAddable={true}
         isDeleteable={true}
         isEditable={true}
         openAddModal={openAddModal}
         openEditModal={openEditModal}
         openDeleteModal={openDeleteModal}>
        </DataTableComponent>
    </div> );
}

export default ClassManagePage;