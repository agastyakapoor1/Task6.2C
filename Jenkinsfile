pipeline {
    agent any

    environment {
        EMAIL_RECIPIENT = 'your-email@example.com'
    }

    stages {
        stage('Build') {
            steps {
                echo 'Building the application...'
                sh 'mvn clean package' 
            }
        }

        stage('Unit and Integration Tests') {
            steps {
                echo 'Running unit and integration tests...'
                sh 'mvn test' 
            }
        }

        stage('Code Analysis') {
            steps {
                echo 'Performing code analysis...'
                sh 'sonar-scanner' 
            }
        }

        stage('Security Scan') {
            steps {
                echo 'Performing security scan...'
                sh 'dependency-check.sh' 
            }
            post {
                always {
                    mail to: "${EMAIL_RECIPIENT}",
                         subject: "Security Scan Results",
                         body: "Check Jenkins logs for details.",
                         attachLog: true
                }
            }
        }

        stage('Deploy to Staging') {
            steps {
                echo 'Deploying to staging...'
                sh 'scp target/app.jar user@staging-server:/app/'
            }
        }

        stage('Integration Tests on Staging') {
            steps {
                echo 'Running integration tests on staging...'
                sh 'curl -X GET http://staging-server/health-check'
            }
        }

        stage('Deploy to Production') {
            steps {
                echo 'Deploying to production...'
                sh 'scp target/app.jar user@production-server:/app/'
            }
        }
    }

    post {
        always {
            echo 'Pipeline execution complete.'
        }
        failure {
            mail to: "${EMAIL_RECIPIENT}",
                 subject: "Jenkins Pipeline Failed",
                 body: "Check Jenkins for failure logs.",
                 attachLog: true
        }
    }
}
