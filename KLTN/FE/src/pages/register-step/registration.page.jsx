import { useEffect, useState } from "react";
import "./registration.css";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import { useHistory } from "react-router";
import axiosClient from '../../global/axios/axiosClient';
const MAX_STEP = 3;
const RegistrationPage = () => {
  const [step, setStep] = useState(1);
  const [countries, setCountries] = useState([]);
  const mySwal = withReactContent(Swal);
  const history = useHistory();
  const [registerForm, setRegisterForm] = useState({
    schoolName: '',
    abbreviation: '',
    schoolEmail: '',
  });
  let isMounted = false;
  useEffect(() => {
    isMounted = true;
    const fetchCountry = async () => {
      var data = await fetch("https://restcountries.com/v2/all");
      var result = await data.json();
      if (isMounted) {
        setCountries(result);
      }
    };
    fetchCountry();
    return () => {
      isMounted = false;
    };
  }, []);
  const nextStep = () => {
    if (step < MAX_STEP) {
      setStep(step + 1);
    }
  };
  const previousStep = () => {
    if (step > 1) {
      setStep(step - 1);
    }
  };
  const openSuccessModal = () => {
    mySwal
      .fire({
        icon: "info",
        html: (
          <h2>
            Chúc mừng bạn đã đăng kí thành công <br />
            Vui lòng kiểm tra hộp thư để nhận thêm thông tin
          </h2>
        ),
        confirmButtonText: "OK",
      })
      .then((e) => {
          history.push('/auth');
      });
  };
  let temp = {};
  const valueChange = (e, isFile = false) => {
    temp[e.target.name] = e.target.value;
    if(!isFile){
      setRegisterForm({
        ...registerForm,
        [e.target.name]: e.target.value
      });
    }
    else{
      setRegisterForm({
        ...registerForm,
        [e.target.name]: e.target.files[0]
      });
    }
  };
  const submit = async () => {
    if (step === 2) {
      console.log("submit form");
      console.log(registerForm);
      console.log(temp);
      const form = new FormData();
      Object.keys(registerForm).forEach((key) => {
        form.append(key, registerForm[key])
      });
      var result = await axiosClient.post("api/identity/domain/register", form);
      if(result.status === 200){
        openSuccessModal();
      }
    }
  };
  return (
    <div className="registration-page">
      {step === 1 && (
        <>
          <form className="form">
            <h2>Hoàn tất hồ sơ</h2>
            <div className="form-group">
              <label>Your school name</label>
              <br />
              <input
                onChange={(e) => valueChange(e)}
                name="schoolName"
                className="form-field"
                type="text"
              />
            </div>
            <div className="form-group">
              <label>Your school abbreviation</label>
              <br />
              <input
                onChange={(e) => valueChange(e)}
                name="abbreviation"
                className="form-field"
                type="text"
              />
            </div>
            <div className="form-group">
              <label htmlFor="">Your school logo</label>
              <br />
              <input
                onChange={(e) => valueChange(e, true)}
                name="file"
                type="file"
                className="form-field"
                accept="image/png, image/gif, image/jpeg"
              />
            </div>
            <div className="form-group">
              <label htmlFor="">Your school email domain</label>
              <br />
              <input
                onChange={(e) => valueChange(e)}
                name="schoolEmail"
                type="text"
                className="form-field"
              />
            </div>
          </form>
          <div className="d-flex align-center">
            <button className="btn btn-2x btn-primary" onClick={nextStep}>
              Next{" "}
              <ion-icon size="large" name="arrow-forward-outline"></ion-icon>
            </button>
          </div>
        </>
      )}
      {step === 2 && (
        <>
          <form className="form">
            <h2>Hoàn tất hồ sơ</h2>
            <div className="form-group">
              <label htmlFor="">Nation</label>
              <select
                name="nation"
                onChange={(e) => valueChange(e)}
                defaultValue={""}
                className="form-field"
              >
                <option value="">Your country</option>
                <option value="Viet name">Viet Name</option>
                {countries.map((country, idx) => (
                  <option key={idx} value={country.name}>
                    {country.name}
                  </option>
                ))}
              </select>
            </div>
            <div className="form-group">
              <label htmlFor="">Website url</label>
              <br />
              <input
                onChange={(e) => valueChange(e)}
                name="schoolUrl"
                placeholder="Your school address"
                type="text"
                className="form-field"
              />
            </div>
            <div className="form-group">
              <label htmlFor="">Address</label>
              <br />
              <input
                onChange={(e) => valueChange(e)}
                name="schoolAddress"
                placeholder="Your school address"
                type="text"
                className="form-field"
              />
            </div>
          </form>
          <div className="d-flex center">
            <button className="btn btn-2x btn-primary" onClick={previousStep}>
              <ion-icon size="large" name="arrow-back-outline"></ion-icon>{" "}
              Previous
            </button>
            <button className="btn btn-2x btn-primary" onClick={submit}>
              Submit
            </button>
          </div>
        </>
      )}
    </div>
  );
};

export default RegistrationPage;
