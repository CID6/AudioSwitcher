﻿using System;
using System.Threading.Tasks;

namespace AudioSwitcher.Scripting
{
    public abstract class ScriptEngineBase : IScriptEngine
    {

        public abstract string FriendlyName
        {
            get;
        }

        public abstract void SetOutput(IScriptOutput output);

        public abstract void AddLibrary(string name, IScriptLibrary libraryInstance);
        public abstract void AddLibrary(string name, Func<IScriptEngine, IScriptLibrary> libraryInstance);

        public ExecutionResult Execute(string script)
        {
            return Execute(new StringScriptSource(script));
        }

        public Task<ExecutionResult> ExecuteAsync(string script)
        {
            return Task.Factory.StartNew(() => Execute(script));
        }

        public abstract ExecutionResult Execute(IScriptSource scriptSource);

        public Task<ExecutionResult> ExecuteAsync(IScriptSource scriptSource)
        {
            return Task.Factory.StartNew(() => Execute(scriptSource));
        }

        public ExecutionResult<TReturn> Evaluate<TReturn>(string script)
        {
            return Evaluate<TReturn>(new StringScriptSource(script));
        }

        public Task<ExecutionResult<TReturn>> EvaluateAsync<TReturn>(string script)
        {
            return Task.Factory.StartNew(() => Evaluate<TReturn>(script));
        }

        public abstract ExecutionResult<TReturn> Evaluate<TReturn>(IScriptSource scriptSource);

        public Task<ExecutionResult<TReturn>> EvaluateAsync<TReturn>(IScriptSource scriptSource)
        {
            return Task.Factory.StartNew(() => Evaluate<TReturn>(scriptSource));
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            
        }

    }
}