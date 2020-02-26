class LiveForm
{
    constructor(form)
    {
        this.form = form;
        this.container = document.getElementById(this.form.dataset.container);

        this.inputs = this.form.getElementsByTagName("INPUT");
        for (let i = 0; i < this.inputs.length; i++)
        {
            let input = this.inputs[i];
            input.addEventListener('change', this.onChange.bind(this));
        }
    }

    onChange()
    {
        let formData = new FormData(this.form);

        fetch(this.form.action, {
            method: this.form.method,
            headers: {
                'X-Requested-With': 'XMLHttpRequest',
            },
            body: formData
        })
            .then(response => response.text())
            .then(response => this.container.innerHTML = response)
            .catch(error => console.error('Error:', error));
    }
}

// Make an object for each individual

let _elements = document.getElementsByClassName("LiveForm");
for (var i = 0; i < _elements.length; i++)
{
    let _element = _elements[i];
    new LiveForm(_element);
}