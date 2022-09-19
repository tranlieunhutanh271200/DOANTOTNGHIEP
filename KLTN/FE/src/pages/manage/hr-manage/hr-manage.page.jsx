import { useHistory } from 'react-router-dom';
import DataTableComponent from '../../../components/datatable/datatable.component';
import './hr-manage.css'
import Modal, {
  ModalBody,
  ModalFooter,
  ModalHeader,
  ModalTitle,
  ModalTransition,
} from "@atlaskit/modal-dialog";
import { ACTION } from "../../../consts/action.const";
import Tabs,{Tab} from 'react-best-tabs';
import 'react-best-tabs/dist/index.css';
const data = [
    {
      id: 1,
      title: "Nhut Anh",
      image:
        "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
    },
    {
      id: 2,
      title: "Nhut Anh",
      image:
        "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
    },
    {
      id: 3,
      title: "Nhut Anh",
      image:
        "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
    },
    {
      id: 4,
      title: "Nhut Anh",
      image:
        "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
    },
    {
      id: 5,
      title: "Nhut Anh",
      image:
        "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
    },
    {
      id: 6,
      title: "Nhut Anh",
      image:
        "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
    },
    {
      id: 7,
      title: "Nhut Anh",
      image:
        "https://media.istockphoto.com/photos/random-multicolored-spheres-computer-generated-abstract-form-of-large-picture-id1295274245?b=1&k=20&m=1295274245&s=170667a&w=0&h=4t-XT7aI_o42rGO207GPGAt9fayT6D-2kw9INeMYOgo=",
    },
  ];
const HRManagePage = () => {
    const {location} = useHistory();
   
    return ( <div className='hr-manage-page'>
    </div> );
}

export default HRManagePage;