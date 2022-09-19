import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";
import DataTableComponent from "../../../components/datatable/datatable.component";
import "./subject-manage.css";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
const data = [
  {
    id: 1,
    title: "Dai so tuyen tinh",
    image:
      "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
  },
  {
    id: 2,
    title: "Dai so tuyen tinh",
    image:
      "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
  },
  {
    id: 3,
    title: "Dai so tuyen tinh",
    image:
      "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
  },
  {
    id: 4,
    title: "Dai so tuyen tinh",
    image:
      "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
  },
  {
    id: 5,
    title: "Dai so tuyen tinh",
    image:
      "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
  },
  {
    id: 6,
    title: "Dai so tuyen tinh",
    image:
      "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
  },
  {
    id: 7,
    title: "Dai so tuyen tinh",
    image:
      "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
  },
];
const SubjectManagePage = () => {
  const { location } = useHistory();
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
  return (
    <div className="subject-manage-page">
      <DataTableComponent
        rows={data}
        headerTitle={"Subject manager"}
        idColumn="id"
        imageColumns="image"
        isAddable={true}
        isDeleteable={true}
        isEditable={true}
        editUrl={`${location.pathname}/:id`}
        openAddModal={openAddModal}
        openEditModal={openEditModal}
        openDeleteModal={openDeleteModal}
      ></DataTableComponent>
      {/* <Link to={`${location.pathname}/${2}`}>move</Link> */}
    </div>
  );
};

export default SubjectManagePage;
