using AlizeeEngine;

class DynamicLightSystem: ClodoBehaviour {

    public override void OnUpdate() {

        Entities.ForEach( (Light light) => {
            if (light.Increase)
                Increase(light);
            else
                Decrease(light);
        });

    }

    private void Increase(Light light) {
        if (light.Radius >= light.MaxRadius)
            light.Increase = false;
        else
            light.Radius += light.Speed * Time.deltaTime;
    }

    private void Decrease(Light light) {
        if (light.Radius <= light.MinRadius)
            light.Increase = true;
        else
            light.Radius -= light.Speed * Time.deltaTime;
    }

}