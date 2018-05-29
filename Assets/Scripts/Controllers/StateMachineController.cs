using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runner.Controllers
{

    public class StateMachineController
    {

        private string _currentState;

        private Dictionary<string, AISMState> _states = new Dictionary<string, AISMState>();

        private MonoBehaviour _self;

        private Coroutine _mainCoroutine;

        private string _prevState;




        public string PrevState
        {
            get
            {
                return _prevState;
            }
        }




        public delegate IEnumerator AISMState();





        public StateMachineController(MonoBehaviour self)
        {
            _self = self;
        }


        public void AddState(string name, AISMState state)
        {
            _states[name] = state;
        }

        public void Start(string stateName)
        {
            _currentState = stateName;
            _mainCoroutine = _self.StartCoroutine(StateController());
        }

        public void Stop()
        {
            _self.StopCoroutine(_mainCoroutine);
        }


        private IEnumerator StateController()
        {
            object stateRes = _currentState;

            while (true)
            {
                IEnumerator stateExecution = _states[_currentState]();

                while (stateExecution.MoveNext())
                {
                    stateRes = stateExecution.Current;
                    yield return stateRes;
                }

                _prevState = _currentState;
                _currentState = (stateRes as string);
            }
        }

    }

}